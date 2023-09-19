using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.API.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource
                {
                    Name = "exam_api",
                    DisplayName = "Exam API"
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new ApiScope[]
            {
                new ApiScope("full_access")
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientUrls)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "exam_web_app",
                    ClientName = "Exam Web App Client",
                    ClientSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        },
                    ClientUri = clientUrls["ExamWebApp"],
                    AllowedCorsOrigins = { clientUrls["ExamWebApp"] },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["ExamWebApp"]}/authentication/login-callback"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["ExamWebApp"]}/authentication/logout-callback"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "full_access"
                    },
                    AccessTokenLifetime = 60 * 60 * 2,
                    IdentityTokenLifetime = 60 * 60 * 2,
                    RequireClientSecret = true
                },
                new Client
                {
                    ClientId = "exam_web_admin",
                    ClientName = "Exam Web Admin Client",
                    ClientSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        },
                    ClientUri = clientUrls["ExamWebAdmin"],
                    AllowedCorsOrigins = { clientUrls["ExamWebAdmin"] },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["ExamWebAdmin"]}/authentication/login-callback"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["ExamWebAdmin"]}/authentication/logout-callback"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "full_access"
                    },
                    AccessTokenLifetime = 60 * 60 * 2,
                    IdentityTokenLifetime = 60 * 60 * 2,
                    RequireClientSecret = true
                },
                new Client
                {
                    ClientId = "exam_api_swaggerui",
                    ClientName = "Exam Api Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["ExamApi"]}/swagger/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["ExamApi"]}/swagger/"
                    },
                    AllowedScopes = new List<string>
                    {
                        "full_access"
                    }
                }
            };
        }
    }
}
