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

global using AccountModuleCore.Enums;
global using AccountModuleCore.TestData.Entities;

global using AccountModuleInfrastructure;
global using AccountModuleInfrastructure.Data;
global using AccountModuleInfrastructure.CommandQuery;

global using AccountModuleApplication;
global using AccountModuleApplication.Automaps;
global using AccountModuleApplication.Shared.Requests;
global using AccountModuleApplication.Shared.ViewModels;
global using AccountModule.Data.Interfaces;
global using AccountModule.Data.SeedScripts;


