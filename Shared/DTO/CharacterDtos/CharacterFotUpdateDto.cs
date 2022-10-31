﻿using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace SharedHelpers.DTO.CharacterDtos;

public record CharacterFotUpdateDto
{
    public Guid Id { get; set; }
    public string UserEmail { get; set; }
    public string CharacterName { get; set; }
    public int Level { get; set; }
    public Skills? Skills { get; set; }
    public int Money { get; set; }
}
