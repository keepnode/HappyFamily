using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyFamily.UserIdentityServer
{
    public class Config
    {
        public static IConfiguration Configuration { get; set; }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("clientservice", "CAS client Service"),
                new ApiResource("productservice", "CAS Product Service"),
                new ApiResource("agentservice", "CAS Agent Service")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client.api.service",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("clientsecret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "clientservice" }
                },
                new Client
                {
                    ClientId = "product.api.service",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("productsecret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "clientservice","productservice" }
                },
                new Client
                {
                    ClientId = "agent.api.service",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("agentsecret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "clientservice","agentservice" }
                }
            };
        }

        public static IEnumerable<TestUser> GetUser()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId="1001",
                    Username="neolu",

                    Password="neolu"
                },
                new TestUser
                {
                    SubjectId="1002",
                    Username="neolu2",
                    Password="neolu2"
                },
                new TestUser
                {
                    SubjectId="1003",
                    Username="neolu3",
                    Password="neolu3"
                },
            };
        }
    }
}
