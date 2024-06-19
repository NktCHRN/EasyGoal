﻿using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Entities.History;
public class HistoricalRecord : BaseEntity
{
    public DateOnly Date { get; private set; }
    public int CurrentDoneItems { get; private set; }
    public int CurrentTotalItems { get; private set; }

    public Guid SubGoalId { get; private set; }
    public SubGoal SubGoal { get; private set; } = null!;

    private HistoricalRecord() { }

    public static HistoricalRecord Create(Guid subGoalId)
    {
        return new HistoricalRecord
        {
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
            SubGoalId = subGoalId,
        };
    }

    public void AddNewItem()
    {
        CurrentTotalItems++;
    }

    public void AddDoneItem()
    {
        CurrentDoneItems++;
    }
}