// Simple Task Manager
// Copyright (C) 2024-2025 Matei Pralea <matei.pralea@proton.me>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

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