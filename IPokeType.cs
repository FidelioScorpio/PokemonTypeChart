using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTypeChart
{
    interface IPokeType
    {
        public enum Effectiveness // {} type moves are ... (...x) against {} type pokemon
        {
            _____Normal,
            __SuperWeak,
            _______Weak,
            ___NoEffect,
            _____Strong,
            SuperStrong
        }
        bool RequestGrid(int generation, out string gameNames, out int numTypes, out string[] types, out Effectiveness[] grid);

        String LookupTypeVsMove(Effectiveness e, String pokemonType, String moveType);

        String LookupMoveVsType(Effectiveness e, String moveType, String targetType);
        
        float GetNumber(IPokeType.Effectiveness effectiveness);

        Effectiveness CombineTypes(Effectiveness e1, Effectiveness e2);

    }
}
