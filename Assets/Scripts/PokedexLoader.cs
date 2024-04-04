using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PokeApiNet;
using System.Linq;
using UnityEngine.UI;
using System;

public class PokedexLoader : MonoBehaviour
{
    [SerializeField] private PokedexEntry pokedexEntryPrefab;
    [SerializeField] private Image holder;
    [SerializeField] private Transform scrollRectContent;
    private List<PokedexEntry> pokedexEntries = new List<PokedexEntry>();
    private int selectedEntryIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        LoadPokedex();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void LoadPokedex()
    {
        var pokeClient = new PokeApiClient();
        var unovadex = await pokeClient.GetResourceAsync<Pokedex>("updated-unova");
        foreach (var entry in unovadex.PokemonEntries)
        {
            string name = string.Empty;
            PokemonSpecies species = await pokeClient.GetResourceAsync(entry.PokemonSpecies);
            foreach (var flavor in species.Names)
            {
                if (flavor.Language.Name == "ja")
                {
                    name = flavor.Name;
                    break;
                }
            }
            Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>(species.Id);
            GameObject entryobj = Instantiate(pokedexEntryPrefab.gameObject, scrollRectContent);
            PokedexEntry pokedexEntry = entryobj.GetComponent<PokedexEntry>();
            pokedexEntry.Init((uint)entry.EntryNumber,(uint)pokedexEntries.Count, holder, name, pokemon.Sprites.FrontDefault);
            pokedexEntry.OnClickEvent += OnPokedexEntryClick;
            pokedexEntries.Add(pokedexEntry);
        }
        //    for (uint i = 0; i <= 2; i++)
        //    { 
        //    string name = string.Empty;
        //    Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>("pikachu");
        //    PokemonSpecies species = await pokeClient.GetResourceAsync(pokemon.Species);
        //    foreach (var flavor in species.Names)
        //    {
        //        if (flavor.Language.Name == "ja")
        //        {
        //            name = flavor.Name;
        //            break;
        //        }
        //    }
        //    GameObject entryobj = Instantiate(pokedexEntryPrefab.gameObject, scrollRectContent);
        //    PokedexEntry pokedexEntry = entryobj.GetComponent<PokedexEntry>();
        //    pokedexEntry.Init(i,i, holder, name, pokemon.Sprites.FrontDefault);
        //    pokedexEntry.OnClickEvent += OnPokedexEntryClick;
        //    pokedexEntries.Add(pokedexEntry);
        //}

    }

    private void OnPokedexEntryClick(PokedexEntry entry, uint index)
    {
        holder.color=new Color(1,1,1,1);
        if (index == selectedEntryIndex)
        {

        }
        else
        {
            if (selectedEntryIndex != -1)
            {
                pokedexEntries[selectedEntryIndex].IsHighlighted = false;
            }
            entry.IsHighlighted = true;
            selectedEntryIndex = (int)index;
        }
    }
}
