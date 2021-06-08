using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class TextConsoleSimulator : MonoBehaviour
    {
        private TMP_Text m_TextComponent;
        [SerializeField] private TMP_Text m_NameTextComponent;
        private bool hasTextChanged;
        [SerializeField] private float charSpeed = 0.02f;
        private bool completeSentence = false;
        private int totalVisibleCharacters;
        private int visibleCount;
        [SerializeField] private Button nextButton;
        [TextArea]
        [SerializeField] private string[] nextSentece;
        [SerializeField] private string[] nextName;
        private Image panelImg;
        [SerializeField] private Color[] panelColor;
        private int sentenceIndex;

       void Awake()
        {
            m_TextComponent = gameObject.GetComponent<TMP_Text>();
            panelImg = gameObject.GetComponentInParent<Image>();
        }


        void Start()
        {
            visibleCount = 0;
            StartCoroutine(RevealCharacters(m_TextComponent));
            //StartCoroutine(RevealWords(m_TextComponent));
        }

        public void CompleteSentece()
        {
            completeSentence = true;
        }

        void OnEnable()
        {
            // Subscribe to event fired when text object has been regenerated.
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
        }

        void OnDisable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
        }


        // Event received when the text object has changed.
        void ON_TEXT_CHANGED(Object obj)
        {
            hasTextChanged = true;
        }


        /// <summary>
        /// Method revealing the text one character at a time.
        /// </summary>
        /// <returns></returns>
        IEnumerator RevealCharacters(TMP_Text textComponent)
        {
            
            textComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = textComponent.textInfo;
            totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
            visibleCount = 0;

            while (true)
            {
                if (hasTextChanged)
                {
                    
                    totalVisibleCharacters = textInfo.characterCount; // Update visible character count.
                    yield return new WaitForSeconds(charSpeed);
                    hasTextChanged = false; 
                }

                if (visibleCount > totalVisibleCharacters)
                {
                    completeSentence = true;
                }
                if (completeSentence)
                {
                    visibleCount = textInfo.characterCount;
                    nextButton.gameObject.SetActive(true);
                    StopCoroutine(RevealCharacters(m_TextComponent));
                }

                textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                visibleCount += 1;
                yield return null;
            }
        }

        public void NextSentence()
        {
            if (sentenceIndex < nextSentece.Length)
            {
                sentenceIndex+=1;
                m_NameTextComponent.text = nextName[sentenceIndex];
                //m_TextComponent.text = nextSentece[sentenceIndex];
                panelImg.color = panelColor[sentenceIndex];
               
                nextButton.gameObject.SetActive(false);
                m_TextComponent.textInfo.characterCount = 0;
                m_TextComponent.SetText(nextSentece[sentenceIndex]);
                StartCoroutine(RevealCharacters(m_TextComponent));
            }
            else
            {
                panelImg.gameObject.SetActive(false);
            }
            
        }
        /// <summary>
        /// Method revealing the text one word at a time.
        /// </summary>
        /// <returns></returns>
        IEnumerator RevealWords(TMP_Text textComponent)
        {
            textComponent.ForceMeshUpdate();

            int totalWordCount = textComponent.textInfo.wordCount;
            int totalVisibleCharacters = textComponent.textInfo.characterCount; // Get # of Visible Character in text object
            int counter = 0;
            int currentWord = 0;
            int visibleCount = 0;

            while (true)
            {
                currentWord = counter % (totalWordCount + 1);

                // Get last character index for the current word.
                if (currentWord == 0) // Display no words.
                    visibleCount = 0;
                else if (currentWord < totalWordCount) // Display all other words with the exception of the last one.
                    visibleCount = textComponent.textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
                else if (currentWord == totalWordCount) // Display last word and all remaining characters.
                    visibleCount = totalVisibleCharacters;

                textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                // Once the last character has been revealed, wait 1.0 second and start over.
                if (visibleCount >= totalVisibleCharacters)
                {
                    yield return new WaitForSeconds(1.0f);
                }

                counter += 1;

                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}