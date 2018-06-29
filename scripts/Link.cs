public class Link
{
    int objectId;
    string name;
    string linkType;

    public Link(int anId, string aName, string aLinkType)
    {
        objectId = anId;
        name = aName;
        linkType = aLinkType;
    }

    public int GetObjectId()
    {
        return objectId;
    }

    public string GetName()
    {
        return name;
    }

    public string GetLinkType()
    {
        return linkType;
    }
}
