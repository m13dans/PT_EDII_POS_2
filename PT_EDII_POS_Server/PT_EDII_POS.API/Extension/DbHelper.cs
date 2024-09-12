using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Infrastructure.DataContext;

namespace PT_EDII_POS.API.Extension;

public static class DbHelper
{
  public static void ApplyMigration(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    context!.Database.Migrate();
  }
}