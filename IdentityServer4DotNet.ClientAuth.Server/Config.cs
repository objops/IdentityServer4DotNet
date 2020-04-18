﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4DotNet.ClientAuth.Server
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("api1", "我的 API")
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
    {
        new TestUser
        {
            SubjectId="1",
            Username="爱丽丝",
            Password="password"
        },
        new TestUser
        {
            SubjectId="2",
            Username="博德",
            Password="password"
        }
    };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        new Client
        {
            ClientId = "client",

            // 没有交互性用户，使用 clientid/secret 实现认证。
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // 用于认证的密码
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            // 客户端有权访问的范围（Scopes）
            AllowedScopes = { "api1" }
        }
        ,
        new Client
        {
            ClientId = "ro.client",

            // 没有交互性用户，使用 clientid/secret 实现认证。
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

            // 用于认证的密码
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            // 客户端有权访问的范围（Scopes）
            AllowedScopes = { "api1" }
        }
    };
        }
    }
}
