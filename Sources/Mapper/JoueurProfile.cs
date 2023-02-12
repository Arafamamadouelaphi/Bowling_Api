using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

public class JoueurProfile:Profile
{/// <summary>
 /// Ce constructeur définit la configuration de mapping entre le type `JoueurDTO` et le type `JoueurEntity`.
 /// Il utilise la méthode `CreateMap` pour définir la façon dont les propriétés des objets sont mappées entre les deux types.
 /// La méthode `ReverseMap` permet également de définir une configuration de mapping inverse, pour mapper les propriétés des objets `JoueurEntity` vers des objets `JoueurDTO`.
 /// </summary>
    public JoueurProfile()
    {
        CreateMap<JoueurDTO, JoueurEntity>().ReverseMap();
    }
}