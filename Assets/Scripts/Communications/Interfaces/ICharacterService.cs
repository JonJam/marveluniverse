﻿namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Model.Character;

    /// <summary>
    /// Interface for a character service.
    /// </summary>
    public interface ICharacterService
    {
        /// <summary>
        /// Performs a character search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>        
        IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Character>>> callback);

        /// <summary>
        /// Get character.
        /// </summary>
        /// <param name="characterUri">The character URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator GetCharacter(
            string characterUri,
            Action<IResult<Character>> callback);
    }
}
