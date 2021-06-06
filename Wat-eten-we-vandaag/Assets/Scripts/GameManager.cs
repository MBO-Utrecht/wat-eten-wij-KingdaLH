using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<Recipe> allRecipes;
    public TMPro.TMP_Text[] dailyRecipesTexts;
    public TMPro.TMP_Text ingredientName;
    public TMPro.TMP_Text ingredientText;
    // Start is called before the first frame update
    void Start()
    {
        LoadRecipe();
        if (ingredientText && ingredientName != null)
        {
            ShowIngredients();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    
    private void LoadRecipe()
    {
        allRecipes = Resources.LoadAll<Recipe>("Recipes").ToList();
        Debug.Log(allRecipes.Count);
    }
    
    public void RandomRecipe()
    {
        for (int i = 0; i < 7; i++)
        {
            Button RecipeButton = dailyRecipesTexts[i].gameObject.GetComponentInParent<Button>();
            Recipe.Kitchen dailyKitchen = (Recipe.Kitchen) i;
            var recipesOfDailyKitchen = allRecipes.Where(x => x.kitchen == dailyKitchen).ToList();
            if (recipesOfDailyKitchen.Count == 0)
            {
                Debug.Log(dailyKitchen);
            }
            
            Recipe dailyRecipe = recipesOfDailyKitchen.ElementAt(Random.Range(0, recipesOfDailyKitchen.Count));
            dailyRecipesTexts[i].text = dailyRecipe.name;
            RecipeButton.onClick.RemoveAllListeners();
            RecipeButton.onClick.AddListener(() => Ingredients(recipeName: dailyRecipe.name));
        }
    }

    public void Ingredients(string recipeName)
    {
        PlayerPrefs.SetString("SelectedRecipe", recipeName);
        SceneManager.LoadScene(2);
    }

    public void Last()
    {
        var ingredientRecipes = allRecipes.Where(x => x.name == PlayerPrefs.GetString("SelectedRecipe")).FirstOrDefault();
        SceneManager.LoadScene(2);
    }

    private void ShowIngredients()
    {
        var ingredientRecipe = allRecipes.Where(x => x.name == PlayerPrefs.GetString("SelectedRecipe")).FirstOrDefault();
        ingredientName.text = ingredientRecipe.name;

        foreach( string x in ingredientRecipe.ingredients) ingredientText.text +=  x + "\n";
    }
    /* public void RandomRecipe()
     {
         //randomize the list
         allRecipes = Recipe.Kitchen.GetRandomItems(allRecipes.count);
         //put the name of each recipe into the dailyRecipesTexts
         for (int i = 0; i < allRecipes.count; i++)
         {
             dailyRecipe = (allRecipes)i;
             dailyRecipesTexts[i].text = dailyRecipe.name;
         }
     }*/
}


