using System;
using System.Runtime.Serialization;

/// <summary>
/// This stores the data necessary to show an article
/// </summary>
[Serializable]
public class Article
{
    private String m_uid;
    private String m_author;
    private DateTime m_time;
    private String m_title;
    private String m_contents;
    private String m_parent;
    private int m_votes;

    /// <summary>
    /// Constructor only to be used by deserializer
    /// </summary>
    public Article()
    {
        //Don't do anything
    }

    public Article(string uid, string author, DateTime time, string title, string contents, string parent, int votes)
    {
        m_uid = uid;
        m_votes = votes;
        m_parent = parent;
        m_author = author;
        m_time = time;
        m_title = title;
        m_contents = contents;
    }

    public string Uid
    {
        get { return m_uid; }
        set { m_uid = value; }
    }

    public string Author
    {
        get { return m_author; }
        set { m_author = value; }
    }

    public DateTime Time
    {
        get { return m_time; }
        set { m_time = value; }
    }

    public String TimeString
    {
        get { return Time.ToShortDateString() + " " + Time.ToShortTimeString(); }
    }

    public string Title
    {
        get { return m_title; }
        set { m_title = value; }
    }

    public string Contents
    {
        get { return m_contents; }
        set { m_contents = value; }
    }

    public string Parent
    {
        get { return m_parent; }
        set { m_parent = value; }
    }

    public int Votes
    {
        get { return m_votes; }
        set { m_votes = value; }
    }
}
