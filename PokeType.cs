using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace PokemonTypeChart
{
    
    class PokeType : IPokeType
    {
        private int m_generation = 1;
        private PokeType() { }

        public static PokeType Instance { get; } = new PokeType();

        private String[] getTypes()
        {
            var ret = new List<String>();
            switch (m_generation)
            {
                case 1:
                    return new[]
                    {
                        "Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost",
                        "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon"
                    };
                case 2:
                case 3:
                case 4:
                case 5:
                    return new[]
                    {
                        "Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel",
                        "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark"
                    };
                case 6:
                case 7:
                case 8:
                case 9:
                    return new[]
                    {
                        "Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel",
                        "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark", "Fairy"
                    };
                default:
                    // Unknown Generation
                    return ret.ToArray();
            }
        }

        private string getGameNames()
        {
            switch (m_generation)
            {
                case 1:
                    return "Red, Blue, and Yellow";
                case 2:
                    return "Gold, Silver, and Crystal";
                case 3:
                    return "Ruby, Sapphire, and Emerald; FireRed and LeafGreen";
                case 4:
                    return "Pearl, Diamond, and Platinum; HeartGold and SoulSilver";
                case 5:
                    return "Black, White, Black 2, and White 2";
                case 6:
                    return "X, Y, X 2, and Y 2; Omega Ruby and Alpha Sapphire";
                case 7:
                    return "Sun, Moon, Ultra Sun, and Ultra Moon; Let's Go, Pikachu! and Let's Go, Eevee!";
                case 8:
                    return "Sword and Shield; Legends: Arceus; Brilliant Diamond and Shining Pearl";
                case 9:
                    return "Scarlet and Violet";

                default:
                    return "<Unsupported>";
            }
        }
        private IPokeType.Effectiveness[] getGrid()
        {
            var ret = new List<IPokeType.Effectiveness>();
            switch (m_generation)
            {
                case 1:
                    return new IPokeType.Effectiveness[]
                    {
                        //Normal: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Fighting: 
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness.___NoEffect,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Flying: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Poison: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Ground: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Rock: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon
                        
                        //Bu.g: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak,                                      // Bug, Ghost
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon
                        
                        //Ghost: 
                        IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice,
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Fire: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak,                                                                           // Dragon
                        
                        //Water: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak,                                                                           // Dragon

                        //Grass: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak,                                                                           // Dragon
                        
                        //Electric: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak,                                                                           // Dragon
                        
                        //Psychic: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal,                                                                           // Dragon

                        //Ice: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong,                                                                           // Dragon

                        //Dragon: 
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,                                      // Bug, Ghost
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong,                                                                           // Dragon

                    };
                case 2:
                case 3:
                case 4:
                case 5:
                    return new IPokeType.Effectiveness[]
                    {
                        //Normal: 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 0.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Fighting: 2.0, 1.0, 0.5, 0.5, 1.0, 2.0, 0.5, 0.0, 2.0, 1.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0, 2.0
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Strong, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Dragon, Dark

                        //Flying: 1.0, 2.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0, 0.5, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,  // Dragon, Dark

                        //Poison: 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 0.5, 0.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness.___NoEffect, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Ground: 1.0, 1.0, 0.0, 2.0, 1.0, 2.0, 0.5, 1.0, 2.0, 2.0, 1.0, 0.5, 2.0, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Rock: 1.0, 0.5, 2.0, 1.0, 0.5, 1.0, 2.0, 1.0, 0.5, 2.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark
                        
                        //Bu.g: 1.0, 0.5, 0.5, 0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 2.0, 1.0, 2.0, 1.0, 1.0, 2.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Dragon, Dark
                        
                        //Ghost: 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 0.5
                        IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Dragon, Dark

                        //Steel: 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 0.5, 1.0, 2.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Fire: 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0, 2.0, 0.5, 0.5, 2.0, 1.0, 1.0, 2.0, 0.5, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal,IPokeType.Effectiveness._____Strong, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak,IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal,IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Dragon, Dark
                        
                        //Water: 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 1.0, 1.0, 1.0, 2.0, 0.5, 0.5, 1.0, 1.0, 1.0, 0.5, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Grass: 1.0, 1.0, 0.5, 0.5, 2.0, 2.0, 0.5, 1.0, 0.5, 0.5, 2.0, 0.5, 1.0, 1.0, 1.0, 0.5, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Dragon, Dark
                        
                        //Electric: 1.0, 1.0, 2.0, 1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 0.5, 1.0, 1.0, 0.5, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Dragon, Dark
                        
                        //Psychic: 1.0, 2.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 0.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, // Dragon, Dark

                        //Ice: 1.0, 1.0, 2.0, 1.0, 2.0, 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 2.0, 1.0, 1.0, 0.5, 2.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Dragon: 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Dragon, Dark

                        //Dark: 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 0.5
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Dragon, Dark
                        
                    };
                case 6:
                case 7:
                case 8:
                case 9:
                    return new IPokeType.Effectiveness[]
                    {
                        //Normal: 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Fighting: 2.0, 1.0, 0.5, 0.5, 1.0, 2.0, 0.5, 0.0, 2.0, 1.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0, 2.0, 0.5
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Strong, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong,IPokeType.Effectiveness._______Weak,  // Dragon, Dark, Fairy

                        //Flying: 1.0, 2.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0, 0.5, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Poison: 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 0.5, 0.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness.___NoEffect, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Dragon, Dark, Fairy

                        //Ground: 1.0, 1.0, 0.0, 2.0, 1.0, 2.0, 0.5, 1.0, 2.0, 2.0, 1.0, 0.5, 2.0, 1.0, 1.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Rock: 1.0, 0.5, 2.0, 1.0, 0.5, 1.0, 2.0, 1.0, 0.5, 2.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy
                        
                        //Bu.g: 1.0, 0.5, 0.5, 0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 2.0, 1.0, 2.0, 1.0, 1.0, 2.0, 0.5
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice,
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Dragon, Dark, Fairy
                        
                        //Ghost: 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 0.5, 1.0
                        IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Steel: 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 0.5, 1.0, 2.0, 1.0, 1.0, 2.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Dragon, Dark, Fairy

                        //Fire: 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0, 2.0, 0.5, 0.5, 2.0, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy
                        
                        //Water: 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 1.0, 1.0, 1.0, 2.0, 0.5, 0.5, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Grass: 1.0, 1.0, 0.5, 0.5, 2.0, 2.0, 0.5, 1.0, 0.5, 0.5, 2.0, 0.5, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, // Poison, Ground, Rock
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy
                        
                        //Electric: 1.0, 1.0, 2.0, 1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 0.5, 1.0, 1.0, 0.5, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._______Weak, // Fire, Water, Grass
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy
                        
                        //Psychic: 1.0, 2.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 0.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Ice: 1.0, 1.0, 2.0, 1.0, 2.0, 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 2.0, 1.0, 1.0, 0.5, 2.0, 1.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Strong, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                        //Dragon: 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 0.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness.___NoEffect, // Dragon, Dark, Fairy

                        //Dark: 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 0.5, 0.5
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._______Weak, // Dragon, Dark, Fairy

                        //Fairy: 1.0, 2.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 1.0
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Normal, Fighting, Flying
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Poison, Ground, Rock
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._______Weak, // Bug, Ghost, Steel
                        IPokeType.Effectiveness._______Weak, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Fire, Water, Grass
                        IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, IPokeType.Effectiveness._____Normal, // Electric, Psychic, Ice
                        IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Strong, IPokeType.Effectiveness._____Normal, // Dragon, Dark, Fairy

                    };
                default:
                    // Unknown Generation
                    break;
            }
            return ret.ToArray();
        }

        public String LookupTypeVsMove(IPokeType.Effectiveness e, String pokemonType, String moveType) 
        {
            String ret = "";
            switch (e)
            {
                case IPokeType.Effectiveness.__SuperWeak:
                    ret = "{0} type pokemon are Super Resistant (0.25x) to {1} type moves";
                    break;
                case IPokeType.Effectiveness._______Weak:
                    ret = "{0} type pokemon are Resistant (0.5x) to {1} type moves";
                    break;
                case IPokeType.Effectiveness.___NoEffect:
                    ret = "{0} type pokemon are Immune (0x) to {1} type moves";
                    break;
                case IPokeType.Effectiveness._____Normal:
                    ret = "{0} type pokemon take Normal (1x) damage from {1} type moves";
                    break;
                case IPokeType.Effectiveness._____Strong:
                    ret = "{0} type pokemon are Weak (2x) to {1} type moves";
                    break;
                case IPokeType.Effectiveness.SuperStrong:
                    ret = "{0} type pokemon are Super Weak (4x) to {1} type moves";
                    break;
            }
            return String.Format(ret, pokemonType, moveType);
        }

        public String LookupMoveVsType(IPokeType.Effectiveness e, String moveType, String targetType)
        {
            String ret = "";
            switch (e)
            {
                case IPokeType.Effectiveness.__SuperWeak:
                    ret = "{0} type moves are Super Weak ({1}x) against {2} type pokemon";
                    break;
                case IPokeType.Effectiveness._______Weak:
                    ret = "{0} type moves are Weak ({1}x) against {2} type pokemon";
                    break;
                case IPokeType.Effectiveness.___NoEffect:
                    ret = "{0} type moves have No Effect ({1}x) against {2} type pokemon";
                    break;
                case IPokeType.Effectiveness._____Normal:
                    ret = "{0} type moves deal Normal ({1}x) damage to {2} type pokemon";
                    break;
                case IPokeType.Effectiveness._____Strong:
                    ret = "{0} type moves are Strong ({1}x) against {2} type pokemon";
                    break;
                case IPokeType.Effectiveness.SuperStrong:
                    ret = "{0} type moves are Super Strong ({1}x) against {2} type pokemon";
                    break;
            }            
            
            return String.Format(ret, moveType, GetNumber(e), targetType);
        }

        public IPokeType.Effectiveness CombineTypes(IPokeType.Effectiveness e1, IPokeType.Effectiveness e2)
        {
            // The only error checking that can be done is to check that types have not been combined into super adv or disadv.
            // We can't actually check properly since many combis will be indistinguishable
            if (e1 == IPokeType.Effectiveness.SuperStrong || e1 == IPokeType.Effectiveness.__SuperWeak ||
                e2 == IPokeType.Effectiveness.SuperStrong || e2 == IPokeType.Effectiveness.__SuperWeak)
            {
                throw new ArgumentOutOfRangeException("These types have already been combined");
            }
            if (e1 == IPokeType.Effectiveness.___NoEffect || e2 == IPokeType.Effectiveness.___NoEffect)
            {
                return IPokeType.Effectiveness.___NoEffect;
            }
            if (e1 == IPokeType.Effectiveness._____Normal)
            {
                return e2;
            }
            if (e2 == IPokeType.Effectiveness._____Normal)
            {
                return e1;
            }
            if (e1 == IPokeType.Effectiveness._______Weak && e2 == IPokeType.Effectiveness._______Weak)
            {
                return IPokeType.Effectiveness.__SuperWeak;
            }
            if (e1 == IPokeType.Effectiveness._____Strong && e2 == IPokeType.Effectiveness._____Strong)
            {
                return IPokeType.Effectiveness.SuperStrong;
            }
            return IPokeType.Effectiveness._____Normal;
        }

        public float GetNumber(IPokeType.Effectiveness effectiveness)
        {
            switch (effectiveness)
            {
                case IPokeType.Effectiveness._____Normal:
                    return 1.0f;
                case IPokeType.Effectiveness.__SuperWeak:
                    return 0.25f;
                case IPokeType.Effectiveness._______Weak:
                    return 0.5f;
                case IPokeType.Effectiveness.___NoEffect:
                    return 0.0f;
                case IPokeType.Effectiveness._____Strong:
                    return 2.0f;
                case IPokeType.Effectiveness.SuperStrong:
                    return 4.0f;
                default:
                    return 1.0f;
            }
        }

        public bool RequestGrid(int generation, out string gameNames, out int numTypes, out string[] types, out IPokeType.Effectiveness[] grid)
        {
            gameNames = "";
            numTypes = 0;
            types = new string[0];
            grid = null;
            //validate generation
            if (generation < 1 || generation > 10) return false;

            m_generation = generation;

            gameNames = getGameNames();
            types = getTypes();
            numTypes = types.Length;
            grid = getGrid();

            return true;
        }
    }
}

