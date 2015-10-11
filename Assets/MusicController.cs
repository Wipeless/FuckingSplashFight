using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public AudioMixerSnapshot Default;
    public AudioMixerSnapshot Damaged;
    public AudioMixerSnapshot BassSolo;
    public AudioMixerSnapshot ArpSolo;
    public AudioMixerSnapshot Room1;
    public AudioMixerSnapshot Room1Combat;
    public AudioMixerSnapshot Room1Damaged;
    public AudioMixerSnapshot Room2;
    public AudioMixerSnapshot Room2Damaged;
    public AudioMixerSnapshot Room3;
    public AudioMixerSnapshot Room3Damaged;
    
    public float bpm = 141;


    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Use this for initialization
    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 2;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MusicRoom1"))
        {
            Room1.TransitionTo(m_TransitionIn);
        }
        if (other.CompareTag("MusicRoom2"))
        {
            Room2.TransitionTo(m_TransitionIn);
        }
        if (other.CompareTag("MusicRoom3"))
        {
            Room3.TransitionTo(m_TransitionIn);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MusicRoom1"))
        {
            Room1Combat.TransitionTo(m_TransitionOut);
        }
        if (other.CompareTag("MusicRoom2"))
        {
            Room2.TransitionTo(m_TransitionOut);
        }
        if (other.CompareTag("MusicRoom3"))
        {
            Room3.TransitionTo(m_TransitionOut);
        }
    }
}
