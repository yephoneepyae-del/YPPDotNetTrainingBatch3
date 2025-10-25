using System;
using System.Collections.Generic;

namespace YPPDotNetTrainingBatch3.ConsoleApp3.Database.AppDbContentModels;

public partial class TblProductCategory
{
    public int ProductCategoryid { get; set; }

    public string ProductCategoryCode { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;
}
