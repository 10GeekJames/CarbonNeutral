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

global using WskCore.Enums;
global using WskCore.WskTestData.Entities;

global using WskInfrastructure;
global using WskInfrastructure.Data;
global using WskInfrastructure.CommandQuery;

global using WskApplication;
global using WskApplication.Shared.Automaps;
global using WskApplication.Shared.Requests;
global using WskApplication.Shared.ViewModels;
global using WskApplication.Data.Interfaces;
global using WskApplication.Data.SeedScripts;


