using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static string[] perfects = { "Felicitari!", "Bravo!", "Perfect!", "Extraordinar!" };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Dictionary<string, Word> Words = new Dictionary<string, Word>()
    {      
        { "congratulations", new Word( "Congratulations!", "Felicitari!", "")},
        { "categoryCompleted", new Word( "Category completed!", "Categorie completata!", "")},
        { "backToCategories", new Word( "Back to categories!", "Inapoi la categorii", "")},
        { "continue", new Word( "Continue", "continua", "")},
        { "receivedReward", new Word( "You received a reward!", "Ai primit un premiu!", "")},
        { "claimReward", new Word( "Claim reward", "Revendica premiul", "")},
        { "skip", new Word( "Skip logo", "Urmatorul logo", "")},
        { "backToMenu", new Word( "Back to menu", "Inapoi la meniu", "")},
        { "solve", new Word( "Solve", "Rezolva complet", "")},
        { "reveal", new Word( "Reveal", "Arata litere", "")},
        { "hint", new Word( "Hint", "Indiciu", "")}

    };

    public class Word
    {
        public string en;
        public string ro;
        public string es;

        public Word(string en, string ro, string es)
        {
            this.en = en;
            this.ro = ro;
            this.es = es;
        }
    }
}
