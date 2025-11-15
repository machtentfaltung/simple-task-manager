// Copyright © 2024-2025 Matei Pralea <matei@machtentfaltung.de>
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace TaskManager;

public class Task
{
    public string Title { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string? Description { get; private set; }
    
    public bool IsComplete { get; private set; }

    public Task(string title, DateTime creationDate, string? description = null, bool isComplete = false)
    {
        if (creationDate > DateTime.Now)
            throw new ArgumentOutOfRangeException(nameof(creationDate), "The creation date cannot be in the future.");

        Title = title;
        CreationDate = creationDate;
        Description = description;
        IsComplete = isComplete;
    }

    public void MarkComplete()
    {
        IsComplete = true;
    }
    
    public void MarkIncomplete()
    {
        IsComplete = false;
    }
}
