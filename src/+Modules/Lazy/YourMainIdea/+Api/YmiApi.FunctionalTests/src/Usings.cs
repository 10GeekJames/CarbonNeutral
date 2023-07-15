global using Autofac;
global using Autofac.Extensions.DependencyInjection;

global using FluentAssertions;
global using FluentValidation;

global using MediatR;
global using MediatR.Pipeline;

global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq;
global using System.Net.Http;
global using System.Net.Http.Json;
global using System.Threading.Tasks;

global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;

global using Xunit;

global using CarbonNeutral.KernelShared.Configuration;
global using CarbonNeutral.KernelShared.Interfaces;

global using YmiCore.Enums;
global using YmiCore.YmiTestData.Entities;

global using YmiInfrastructure;
global using YmiInfrastructure.Data;
global using YmiInfrastructure.CommandQuery;

global using YmiApplication;
global using YmiApplication.Automaps;
global using YmiApplication.Shared.Requests;
global using YmiApplication.Shared.ViewModels;
global using YmiApplication.Data.Interfaces;
global using YmiApplication.Data.SeedScripts;


