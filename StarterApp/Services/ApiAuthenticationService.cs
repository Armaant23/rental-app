using System.Net.Http.Json;
using StarterApp.Database.Models;

namespace StarterApp.Services;

public class ApiAuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private User? _currentUser;
    private readonly List<string> _roles = new();

    public event EventHandler<bool>? AuthenticationStateChanged;

    public bool IsAuthenticated => _currentUser != null;

    public User? CurrentUser => _currentUser;

    public List<string> CurrentUserRoles => _roles;

    // HttpClient is injected so the service can talk to the coursework API
    public ApiAuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Sends the email and password to the API and stores the JWT token if login works
    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        try
        {
            var loginRequest = new
            {
                email,
                password
            };

            var response = await _httpClient.PostAsJsonAsync("auth/token", loginRequest);

            if (!response.IsSuccessStatusCode)
            {
                return new AuthenticationResult(false, "Invalid email or password");
            }

            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

            if (tokenResponse == null || string.IsNullOrWhiteSpace(tokenResponse.Token))
            {
                return new AuthenticationResult(false, "Token was not returned by the API");
            }

            // SecureStorage is used so the JWT is not kept as plain text in the app code
            await SecureStorage.SetAsync("jwt_token", tokenResponse.Token);

            // The API returns the user ID, so a basic user object is created for the app session
            _currentUser = new User
            {
                Id = tokenResponse.UserId,
                Email = email,
                FirstName = "API",
                LastName = "User",
                IsActive = true
            };

            AuthenticationStateChanged?.Invoke(this, true);

            return new AuthenticationResult(true, "Login successful");
        }
        catch (Exception ex)
        {
            return new AuthenticationResult(false, $"Login failed: {ex.Message}");
        }
    }

    // Sends registration details to the API
    public async Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        try
        {
            var registerRequest = new
            {
                firstName,
                lastName,
                email,
                password
            };

            var response = await _httpClient.PostAsJsonAsync("auth/register", registerRequest);

            if (!response.IsSuccessStatusCode)
            {
                return new AuthenticationResult(false, "Registration failed. Check password rules or email.");
            }

            return new AuthenticationResult(true, "Registration successful");
        }
        catch (Exception ex)
        {
            return new AuthenticationResult(false, $"Registration failed: {ex.Message}");
        }
    }

    // Clears the saved JWT token and resets the current user
    public async Task LogoutAsync()
    {
        SecureStorage.Remove("jwt_token");

        _currentUser = null;
        _roles.Clear();

        AuthenticationStateChanged?.Invoke(this, false);

        await Task.CompletedTask;
    }

    public bool HasRole(string roleName)
    {
        return _roles.Contains(roleName, StringComparer.OrdinalIgnoreCase);
    }

    public bool HasAnyRole(params string[] roleNames)
    {
        return roleNames.Any(role => HasRole(role));
    }

    public bool HasAllRoles(params string[] roleNames)
    {
        return roleNames.All(role => HasRole(role));
    }

    // Password change is not implemented here because the API reference does not provide that endpoint
    public Task<bool> ChangePasswordAsync(string currentPassword, string newPassword)
    {
        return Task.FromResult(false);
    }

    // This matches the JSON returned from POST /auth/token
    private class TokenResponse
    {
        public string Token { get; set; } = "";

        public DateTime ExpiresAt { get; set; }

        public int UserId { get; set; }
    }
}