﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrendPredictor
{
    public interface IBuySellCriteria
    {
        void Buy();
        void Sell();
        void LogOpenTransaction();
    }
}