﻿namespace RefactoringToPatterns.Strategy.Step4.Strategy
{
    internal class ELearningLicenseCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        internal override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.BaseItemCost;

            if (item.VendorsWithDiscounts.ContainsKey(item.VendorName))
            {
                var discountAmount = totalCost * item.VendorsWithDiscounts[item.VendorName];
                totalCost -= discountAmount;
            }

            var duration = item.EndDate - item.StartDate;

            if (duration.HasValue && duration.Value.Days > 180)
            {
                totalCost *= 0.8m;
            }

            return totalCost;
        }
    }
}