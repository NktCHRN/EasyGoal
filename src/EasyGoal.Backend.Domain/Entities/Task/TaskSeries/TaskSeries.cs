﻿using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Task.TaskSeries;
public abstract class TaskSeries : BaseEntity
{
    public short Period { get; private set; } = 1;
}