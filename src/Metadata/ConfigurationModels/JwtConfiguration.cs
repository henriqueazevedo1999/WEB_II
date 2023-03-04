﻿namespace Entities.ConfigurationModels;

public class JwtConfiguration
{
    public const string SECTION = "JwtSettings";

    public string SecretKey { get; set; }
    public int Expires { get; set; }
}
