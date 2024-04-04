using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class PokedexEntry : MonoBehaviour
{
    public uint IndexinPokedex { get; private set; }
    public uint IndexinCurrentPokemons { get; private set; }
    public delegate void OnClickAction(PokedexEntry entry, uint index);
    public event OnClickAction OnClickEvent;
    public bool IsHighlighted
    {
        get
        {
            return m_isHighlighted;
        }

        set
        {
            if (value)
            {
                entry.sprite = highlighted;
                pokemonimageholder.sprite = pokemonsprite;
            }
            else
            {
                entry.sprite = unhighlighted;
            }
            m_isHighlighted = value;
        }
    }
    private bool m_isHighlighted;
    private Image pokemonimageholder;

    [SerializeField] private Sprite highlighted;
    [SerializeField] private Sprite unhighlighted;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text indexText;
    [SerializeField] private Image pokemonImage;
    private Image entry;
    private Sprite pokemonsprite;
    // Start is called before the first frame update

    public void Init(uint indexinpokedex,uint indexincurrentpokemons, Image holder, string name, string imageurl)
    {
        StartCoroutine(LoadSprite(imageurl));
        IndexinPokedex = (uint)indexinpokedex;
        IndexinCurrentPokemons = (uint)indexincurrentpokemons;
        entry = GetComponent<Image>();
        pokemonimageholder = holder;
        IsHighlighted = false;
        nameText.text = name;
        indexText.text = indexinpokedex.ToString("000");
    }

    public void OnClick()
    {
        OnClickEvent.Invoke(this, IndexinPokedex);
    }

    IEnumerator LoadSprite(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            pokemonsprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            pokemonImage.sprite = pokemonsprite;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
