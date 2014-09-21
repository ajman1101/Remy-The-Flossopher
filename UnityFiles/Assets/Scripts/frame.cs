using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Frame {

	[XmlElement(ElementName = "sprite")]
	public string spriteName { get; set; }

	[XmlElement(ElementName = "text")]
	public string text { get; set; }

	public Sprite sprite {
		get { 
			return Resources.Load(this.spriteName, typeof(Sprite)) as Sprite;
		}
	}
}

[XmlRootAttribute("game")]
public class Game {
	
	[XmlArray("frames")]
	[XmlArrayItem("frame", Type = typeof(Frame))]
	public Frame[] getFrames;


}
