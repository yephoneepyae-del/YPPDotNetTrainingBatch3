using System;
using System.Collections.Generic;

namespace YPPDotNetTrainingBatch3.ConsoleApp2.Database.AppDbContentModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }
}
