using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
//using System;

namespace Deluxia.Unity{
    public enum CloneNameType{
        /// <summary>
        /// The name will be set to the total number of objects cloned at the time of this object's creation.
        /// </summary>
		total, 
        /// <summary>
        /// The name will be set to the position this object is located in on the grid.
        /// </summary>
        grid, 
        /// <summary>
        /// The name will stay the same.
        /// </summary>
        originalName
	}
    public static class DeluxiaUnityMethods {
        public static MonoBehaviour mainClass;
        /// <summary>
        /// This looks at a numeric input field and sets the number if it's too high or too low.
        /// </summary>
        /// <param name="input">The input field.</param>
        /// <param name="min">The lowest number that can be entered.</param>
        /// <param name="max">The highest number that can be entered.</param>
        /// <returns>The number the text box was set to.</returns>
        public static int SetTextBox(InputField input,int min,int max) {
            int checkNum;
            if(int.TryParse(input.text,out int num)) {
                checkNum = num;
            }
            else {
                return int.Parse(input.placeholder.GetComponent<Text>().text);
            }
            if(checkNum > max) {
                input.text = max + "";
                return max;
            }
            else if(checkNum < min) {
                input.text = min + "";
                return min;
            }
            else {
                return checkNum;
            }
        }
        /// <summary>
        /// This looks at a numeric input field and sets the number if it's too high or too low.
        /// </summary>
        /// <param name="input">The input field.</param>
        /// <param name="min">The lowest number that can be entered.</param>
        /// <param name="max">The highest number that can be entered.</param>
        /// <returns>The number the text box was set to.</returns>
        public static byte SetTextBox(InputField input,byte min,byte max) {
            byte checkNum;
            if(byte.TryParse(input.text,out byte num)) {
                checkNum = num;
            }
            else {
                return byte.Parse(input.placeholder.GetComponent<Text>().text);
            }
            if(checkNum > max) {
                input.text = max + "";
                return max;
            }
            else if(checkNum < min) {
                input.text = min + "";
                return min;
            }
            else {
                return checkNum;
            }
        }
        /// <summary>
        /// This looks at a numeric input field and sets the number if it's too high or too low.
        /// </summary>
        /// <param name="input">The input field.</param>
        /// <param name="min">The lowest number that can be entered.</param>
        /// <param name="max">The highest number that can be entered.</param>
        /// <returns>The number the text box was set to.</returns>
        public static int SetTextBox(TMP_InputField input,int min,int max) {
            int checkNum;
            if(int.TryParse(input.text,out int num)) {
                checkNum = num;
            }
            else {
                return int.Parse(input.placeholder.GetComponent<Text>().text);
            }
            if(checkNum > max) {
                input.text = max + "";
                return max;
            }
            else if(checkNum < min) {
                input.text = min + "";
                return min;
            }
            else {
                return checkNum;
            }
        }
        /// <summary>
        /// This looks at a numeric input field and sets the number if it's too high or too low.
        /// </summary>
        /// <param name="input">The input field.</param>
        /// <param name="min">The lowest number that can be entered.</param>
        /// <param name="max">The highest number that can be entered.</param>
        /// <returns>The number the text box was set to.</returns>
        public static byte SetTextBox(TMP_InputField input,byte min,byte max) {
            byte checkNum = 0;
            if(byte.TryParse(input.text,out byte num)) {
                checkNum = num;
            }
            else {
                return byte.Parse(input.placeholder.GetComponent<Text>().text);
            }
            if(checkNum > max) {
                input.text = max + "";
                return max;
            }
            else if(checkNum < min) {
                input.text = min + "";
                return min;
            }
            else {
                return checkNum;
            }
        }
        public static IEnumerator Fade2Can(CanvasGroup CA,CanvasGroup CB,float speed) {
            float opacityT = 0f;
            float inverseT = 255f;
            CA.GetComponent<Canvas>().enabled = true;
            CA.interactable = true;
            CB.interactable = false;
            while(opacityT < 255) {
                //Debug.Log(opacityT);
                CA.alpha = opacityT / 255f;
                CB.alpha = inverseT / 255f;
                opacityT += speed;
                inverseT -= speed;
                yield return new WaitForSeconds(0.01f);
            }
            CB.GetComponent<Canvas>().enabled = false;
            CA.alpha = 1;
            CB.alpha = 0;
        }

        public static IEnumerator Move2Rect(RectTransform RA,RectTransform RB,Vector3 AStart,Vector3 AEnd,Vector3 BEnd,float speed,bool disableOnDone) {
            float spot = 0;
			speed /= 100f;
			if(disableOnDone) {
                RA.gameObject.SetActive(true);
            }
            Vector3 middle = RB.anchoredPosition;
            while(spot <= 1) {
                //Debug.Log(opacityT);
                spot += speed;
                RA.anchoredPosition = Vector3.Lerp(AStart,AEnd,spot);
                RB.anchoredPosition = Vector3.Lerp(middle,BEnd,spot);
                yield return new WaitForSeconds(0.01f);
            }
            if(disableOnDone) {
                RB.gameObject.SetActive(false);
            }
        }
        public static IEnumerator Move(Transform CA,Vector3 AStart,Vector3 AEnd,float speed,bool disableOnDone,bool useLocal) {
            float spot = 0;
			speed /= 100f;
			while(spot <= 1) {
                //Debug.Log(opacityT);
                if(useLocal) {
                    CA.localPosition = Vector3.Lerp(AStart,AEnd,spot);
                }
                else {
                    CA.position = Vector3.Lerp(AStart,AEnd,spot);
                }
                spot += speed;
                yield return new WaitForSeconds(0.01f);
            }
            if(useLocal) {
                CA.localPosition = AEnd;
            }
            else {
                CA.position = AEnd;
            }
            if(disableOnDone) {
                CA.gameObject.SetActive(false);
            }
        }
        public static IEnumerator Scale(Transform CA,Vector3 AStart,Vector3 AEnd,float speed,bool disableOnDone) {
            float spot = 0;
			speed /= 100f;
			while(spot <= 1) {
                //Debug.Log(opacityT);
                CA.localScale = Vector3.Lerp(AStart,AEnd,spot);
                spot += speed;
                yield return new WaitForSeconds(0.01f);
            }
			CA.localScale = AEnd;
			if(disableOnDone) {
                CA.gameObject.SetActive(false);
            }
        }
        public static IEnumerator Move2(Transform A,Transform B,Vector3 AStart,Vector3 AEnd,Vector3 BEnd,float speed,bool disableOnDone) {
            float spot = 0;
			speed /= 100f;
			if(disableOnDone) {
                A.gameObject.SetActive(true);
            }
            Vector3 middle = B.position;
            while(spot <= 1) {
                //Debug.Log(opacityT);
                spot += speed;
                A.position = Vector3.Lerp(AStart,AEnd,spot);
                B.position = Vector3.Lerp(middle,BEnd,spot);
                yield return new WaitForSeconds(0.01f);
            }
            if(disableOnDone) {
                B.gameObject.SetActive(false);
            }
        }
        public static IEnumerator MoveRect(RectTransform CA,Vector3 AStart,Vector3 AEnd,float speed,bool disableOnDone) {
            float spot = 0;
			speed /= 100f;
			while(spot <= 1) {
                //Debug.Log(opacityT);
                if(CA == null) {
                    yield break;
                }
                spot += speed;
                CA.anchoredPosition = Vector3.Lerp(AStart,AEnd,spot);
                yield return new WaitForSeconds(0.01f);
            }
            if(disableOnDone) {
                CA.gameObject.SetActive(false);
            }
        }
		
		public static IEnumerator MoveRect(RectTransform CA,Vector3 AEnd,float speed,bool disableOnDone) {
            float spot = 0;
            Vector3 start = CA.anchoredPosition;
			speed /= 100f;
			while(spot <= 1) {
                //Debug.Log(opacityT);
                spot += speed;
                CA.anchoredPosition = Vector3.Lerp(start,AEnd,spot);
                yield return new WaitForSeconds(0.01f);
            }
            if(disableOnDone) {
                CA.gameObject.SetActive(false);
            }
        }
		public static IEnumerator ChangeSizeRect(RectTransform CA,Vector2 start,Vector2 AEnd,float speed) {
			float spot = 0;
			speed /= 100f;
			while(spot <= 1) {
				//Debug.Log(opacityT);
				spot += speed;
				CA.sizeDelta = Vector2.Lerp(start,AEnd,spot);
				yield return new WaitForSeconds(0.01f);
			}
		}
		public static IEnumerator ChangeSizeRect(RectTransform CA,Vector2 AEnd,float speed) {
			float spot = 0;
			Vector2 start = CA.sizeDelta;
			speed /= 100f;
			while(spot <= 1) {
				//Debug.Log(opacityT);
				spot += speed;
				CA.sizeDelta = Vector2.Lerp(start,AEnd,spot);
				yield return new WaitForSeconds(0.01f);
			}
		}
        public static IEnumerator MovePivot(RectTransform CA,Vector2 AStart,Vector2 AEnd,float speed,bool disableOnDone) {
			float spot = 0;
			speed /= 100f;
			while(spot <= 1) {
				//Debug.Log(opacityT);
				spot += speed;
				CA.pivot = Vector2.Lerp(AStart,AEnd,spot);
				yield return new WaitForSeconds(0.01f);
			}
			if(disableOnDone) {
				CA.gameObject.SetActive(false);
			}
		}
		public static IEnumerator MovePivot(RectTransform CA,Vector2 AEnd,float speed,bool disableOnDone) {
            Vector2 AStart = CA.pivot;
			float spot = 0;
			speed /= 100f;
			while(spot <= 1) {
				//Debug.Log(opacityT);
				spot += speed;
				CA.pivot = Vector2.Lerp(AStart,AEnd,spot);
				yield return new WaitForSeconds(0.01f);
			}
			if(disableOnDone) {
				CA.gameObject.SetActive(false);
			}
		}
		public static IEnumerator Move2Can(CanvasGroup CA,CanvasGroup CB,Vector3 AStart,Vector3 BEnd,float speed,AnimationCurve curve) {
            float spot = 0;
            speed /= 100f;
			if(CA.TryGetComponent(out Canvas canA)) {
				canA.enabled = true;
			}
            CA.blocksRaycasts = true;
            CB.blocksRaycasts = false;
            RectTransform CAR = CA.GetComponent<RectTransform>();
            RectTransform CBR = CB.GetComponent<RectTransform>();

            Vector3 middle = CBR.anchoredPosition;
            while(spot < 1) {
                //Debug.Log(opacityT);
                CAR.anchoredPosition = Vector3.Lerp(AStart,middle,spot);
                CBR.anchoredPosition = Vector3.Lerp(middle,BEnd,spot);
                spot += speed;
                yield return new WaitForSeconds(0.01f);
            }
            if(CB.TryGetComponent(out Canvas canB)) {
                canB.GetComponent<Canvas>().enabled = false;
            }
        }
        public static IEnumerator FadeCan(CanvasGroup C,float speed,bool fadeIn) {
            C.blocksRaycasts = fadeIn;
            float opacity = fadeIn ? 0f : 255f;
            if(C.TryGetComponent(out Canvas can)){
                can.enabled = true;
            }
            do {
                C.alpha = opacity / 255f;
                opacity += speed * (fadeIn ? 1 : -1);
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            C.alpha = fadeIn ? 1 : 0;
			if(can != null) {
				can.enabled = fadeIn;
			}
		}
        public static IEnumerator FadeCan(CanvasGroup C,float speed,bool fadeIn,System.Action method) {
            float opacity = fadeIn ? 0f : 255f;
			if(C.TryGetComponent(out Canvas can)) {
				can.enabled = true;
			}
			do {
                C.alpha = opacity / 255f;
                opacity += speed * (fadeIn ? 1 : -1);
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            C.alpha = fadeIn ? 1 : 0;
			if(can != null) {
				can.enabled = fadeIn;
			}
			method();
        }
        public static IEnumerator FadeCan(CanvasGroup C,float speed,bool fadeIn,System.Action<string> method,string param) {
            float opacity = fadeIn ? 0f : 255f;
            if(C.TryGetComponent(out Canvas can)) {
				can.enabled = true;
			}
            do {
                C.alpha = opacity / 255f;
                opacity += speed * (fadeIn ? 1 : -1);
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            C.alpha = fadeIn ? 1 : 0;
			if(can != null) {
				can.enabled = fadeIn;
			}
			method(param);
        }
        public static IEnumerator FadeCanInAndOut(CanvasGroup C,bool blockRaycasts,float speed,float time) {
            float opacity = 0f;
            C.blocksRaycasts = blockRaycasts;
            if(C.TryGetComponent(out Canvas can)) {
				can.enabled = true;
			}
            do {
                C.alpha = opacity / 255f;
                opacity += speed;
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            C.alpha = 1;
            yield return new WaitForSeconds(time);
            do {
                C.alpha = opacity / 255f;
                opacity += speed * -1;
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            C.alpha = 0;
            C.blocksRaycasts = false;
			if(can != null) {
                can.enabled = false;
			}
		}
        /// <summary>
        /// Fade a Text Mesh Pro object.
        /// </summary>
        /// <param name="text">The text to use.</param>
        /// <param name="speed">Multiply the speed by this amount.</param>
        /// <param name="fadeIn">Choose if this fades in or out.</param>
        /// <returns></returns>
        public static IEnumerator FadeTMP(TMP_Text text,float speed,bool fadeIn) {
            float opacity = fadeIn ? 0f : 255f;
            do {
                text.alpha = opacity / 255f;
                opacity += speed * (fadeIn ? 1 : -1);
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            text.alpha = fadeIn ? 1 : 0;

        }
        /// <summary>
        /// Fade an Image object.
        /// </summary>
        /// <param name="img">The image to use.</param>
        /// <param name="speed">Multiply the speed by this amount.</param>
        /// <param name="fadeIn">Choose if this fades in or out.</param>
        /// <returns></returns>
        public static IEnumerator FadeImage(Image img,float speed,bool fadeIn) {
            float opacity = fadeIn ? 0f : 255f;
            do {
                img.color = new Color(img.color.r,img.color.g,img.color.b,opacity / 255f);
                opacity += speed * (fadeIn ? 1 : -1);
                yield return new WaitForSeconds(0.01f);
            } while(opacity < 255 && opacity > 0);
            img.color = new Color(img.color.r,img.color.g,img.color.b,fadeIn ? 1 : 0);

        }
        public static IEnumerator ChangeColor(Graphic graphic,Color endColor,float speed) {
            float spot = 0;
            speed /= 100;
            while(spot <= 1) {
                //Debug.Log(opacityT);
                spot += speed;
                graphic.color = Color.Lerp(graphic.color,endColor,spot);
                yield return new WaitForSeconds(0.01f);
            }
        }
        /// <summary>
        /// WARNING!! EXPERIMENTAL!!
        /// Converts a 2D sprite to a UI Image.
        /// </summary>
        /// <param name="sprite">The sprite to convert to an image.</param>
        /// <param name="parent">Set the parent of the image.</param>
        /// <param name="copyChildren">Copy all children from the 2D sprite.</param>
        /// <returns></returns>
        public static Image ConvertSpriteToImage(this SpriteRenderer sprite,Transform parent,bool copyChildren) {
            if(sprite == null || parent == null) return null;
            GameObject toImage = Object.Instantiate(sprite,parent).gameObject;
            Object.Destroy(toImage.GetComponent<SpriteRenderer>());
            if(!copyChildren) {
                foreach(Transform t in toImage.transform.GetComponentInChildren<Transform>()) {
                    if(t != null && t.gameObject != null) {
                        Object.Destroy(t.gameObject);
                    }
                }
            }
            toImage.AddComponent<Image>();
            toImage.GetComponent<Image>().sprite = sprite.sprite;
            toImage.GetComponent<Image>().color = sprite.color;
            toImage.GetComponent<Image>().enabled = sprite.enabled;
            toImage.GetComponent<Image>().SetNativeSize();
            toImage.GetComponent<RectTransform>().localScale = sprite.transform.lossyScale;
            //toImage.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            //toImage.AddComponent<RectTransform>();
            toImage.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(sprite.transform.position);
            return toImage.GetComponent<Image>();

        }
        /// <summary>
        /// Creates a grid of RectTransforms.
        /// </summary>
        /// <param name="original">The original RectTransform</param>
        /// <param name="nameT">This changes the name of all the clones to match the name type. Check the enum for more info.</param>
        /// <param name="XLength">The number of columns (horizontal) in the grid</param>
        /// <param name="YLength">The number of rows (vertical) in the grid.</param>
        /// <param name="max">The max number of objects in the grid.</param>
        /// <param name="moveByX">Move the x position this much on every object. Resets on new row.</param>
        /// <param name="moveByY">Move the y position this much on every new row.</param>
        /// <param name="destroyOriginal">Destroy the original object when the grid is finished.</param>
        /// <param name="moveToOriginal">When the x resets on a new row, use the original object's x. If turned of, it will move by "moveByX"</param>
        /// <returns>A 2D array of all the created RectTransforms. Does not include the original.</returns>
        public static RectTransform[,] CreateUIGrid(RectTransform original,CloneNameType nameT,int XLength,int YLength,int max,float moveByX,float moveByY,bool destroyOriginal,bool moveToOriginal) {
            if(YLength == 0 || XLength == 0) {
                return null;
            }
            if(max == -1) {
                max = YLength * XLength;
            }
            RectTransform[,] toSend = new RectTransform[XLength,YLength];
            int total = 0;
            for(int y = 0;y < YLength && total < max;y++) {
                for(int x = 0;x < XLength && total < max;x++) {
                    toSend[x,y] = Object.Instantiate(original.gameObject,original.parent).GetComponent<RectTransform>();
                    toSend[x,y].anchoredPosition = new Vector3(original.anchoredPosition.x + (moveByX * (x + (!moveToOriginal || (!destroyOriginal && y == 0) ? 1 : 0))),original.anchoredPosition.y + (moveByY * y));
                    switch(nameT) {
                        case CloneNameType.total:
                            toSend[x,y].gameObject.name = "" + total;
                            break;
                        case CloneNameType.grid:
                            toSend[x,y].gameObject.name = "[" + x + "," + y + "]";
                            break;
                        case CloneNameType.originalName:
                            toSend[x,y].gameObject.name = original.gameObject.name;
                            break;
                    }
                    total++;
                }
            }
            if(destroyOriginal) {
                Object.Destroy(original.gameObject);
            }
            return toSend;
        }
        /// <summary>
        /// Creates a grid of RectTransforms.
        /// </summary>
        /// <param name="original">The original RectTransform</param>
        /// <param name="nameT">This changes the name of all the clones to match the name type. Check the enum for more info.</param>
        /// <param name="XLength">The number of columns (horizontal) in the grid</param>
        /// <param name="YLength">The number of rows (vertical) in the grid.</param>
        /// <param name="max">The max number of objects in the grid.</param>
        /// <param name="moveByX">Move the x position this much on every object. Resets on new row.</param>
        /// <param name="moveByY">Move the y position this much on every new row.</param>
        /// <param name="destroyOriginal">Destroy the original object when the grid is finished.</param>
        /// <param name="moveToOriginal">When the x resets on a new row, use the original object's x. If turned of, it will move by "moveByX"</param>
        /// <returns>A list of all the created RectTransforms. Does not include the original.</returns>
        public static List<RectTransform> CreateUIGridList(RectTransform original,CloneNameType nameT,int XLength,int YLength,int max,float moveByX,float moveByY,bool destroyOriginal,bool moveToOriginal) {
            if(YLength == 0 || XLength == 0) {
                return null;
            }
            if(max == -1) {
                max = YLength * XLength;
            }
            List<RectTransform> toSend = new();
            int total = 0;
            for(int y = 0;y < YLength && total < max;y++) {
                for(int x = 0;x < XLength && total < max;x++) {
                    RectTransform next = Object.Instantiate(original.gameObject,original.parent).GetComponent<RectTransform>();
                    toSend.Add(next);
                    next.anchoredPosition = new Vector3(original.localPosition.x + (moveByX * (x + (!destroyOriginal && y == 0 ? 1 : 0))),original.localPosition.y + (moveByY * y));
                    switch(nameT) {
                        case CloneNameType.total:
                            next.gameObject.name = "" + total;
                            break;
                        case CloneNameType.grid:
                            next.gameObject.name = "[" + x + "," + y + "]";
                            break;
                        case CloneNameType.originalName:
                            next.gameObject.name = original.gameObject.name;
                            break;
                    }
                    total++;
                }
            }
            if(destroyOriginal) {
                Object.Destroy(original.gameObject);
            }
            return toSend;
        }
        private static void FindMainClass() {
            if(mainClass == null) {
                mainClass = GameObject.Find("GameScriptsManager").GetComponent<MonoBehaviour>();
            }
        }
        /// <summary>
        /// Stop playing one audio clip and start playing another. This destroys the original AudioSource
        /// </summary>
        /// <param name="audio">The AudioSource to fade out. Use one that's currently playing something.</param>
        /// <param name="main">Because this executes a coroutine and this class is not a MonoBehaviour, it needs one to start the coroutine.</param>
        /// <param name="clip">The new audio clip.</param>
        /// <param name="volume">The volume to end at.</param>
        /// <returns></returns>
        public static AudioSource ChangeSong(this AudioSource audio,MonoBehaviour main,AudioClip clip,float volume,float speed,bool destroyWhenDone) {
            if(clip == null) {
                main.StartCoroutine(FadeOutAudio(audio,0,speed,false));
                return audio;
            }
            else {
				main.StartCoroutine(FadeOutAudio(audio,0,speed,destroyWhenDone));
				AudioSource audio2 = audio.gameObject.AddComponent<AudioSource>();
                audio2.loop = audio.loop;
                audio2.playOnAwake = false;
				audio2.volume = 0;
				main.StartCoroutine(FadeInAudio(audio2,clip,0,speed,volume));
				return audio2;
			}

        }
        /// <summary>
        /// Provides a fade in effect for audio.
        /// </summary>
        /// <param name="audio">The AudioSource to fade out. Use one that's currently playing something.</param>
        /// <param name="delay">Have this wait a bit before executing.</param>
        /// <param name="maxVol">The volume to end at.</param>
        /// <param name="destroyWhenDone">Destroy the AudioSource when the fade out is finished.</param>
        public static IEnumerator FadeOutAudio(AudioSource audio,float delay,float speed,bool destroyWhenDone) {
            yield return new WaitForSeconds(delay);
            float spot = 0f;
            float maxVol = audio.volume;
            speed /= 100;
            while(spot < 1) {
                audio.volume = Mathf.Lerp(maxVol,0,spot);
                spot+=speed;
                yield return new WaitForSeconds(0.01f);
            }
            if(destroyWhenDone) {
                Object.Destroy(audio);
            }
            else {
                audio.Stop();
            }
        }
        /// <summary>
        /// Provides a fade in effect for audio.
        /// </summary>
        /// <param name="audio">The AudioSource to fade in. Use one that's not playing anything.</param>
        /// <param name="clip">The clip to fade in.</param>
        /// <param name="delay">Have this wait a bit before executing.</param>
        /// <param name="maxVol">The volume to end at.</param>
        /// <returns></returns>
        public static IEnumerator FadeInAudio(AudioSource audio,AudioClip clip,float delay,float speed,float maxVol) {
			yield return new WaitForSeconds(delay);
			float spot = 0f;
            audio.clip = clip;
            audio.Play();
			speed /= 100;
			while(spot < 1) {
				audio.volume = Mathf.Lerp(0,maxVol,spot);
				spot += speed;
				yield return new WaitForEndOfFrame();
			}
		}
        public static float[] ToFloat(this Vector3 V3) {
            return new float[] { V3.x,V3.y,V3.z };
        }
        public static Vector3 ToRotation(this Vector3 V) {
            float[] toSend = new float[] { V.x,V.y,V.z };
            for(int i = 0;i < 3;i++) {
                while(toSend[i] < 0) {
                    toSend[i] += 360;
                }
                while(toSend[i] > 360) {
                    toSend[i] -= 360;
                }
            }
            return new Vector3(toSend[0],toSend[1],toSend[2]);
        }
        public static Vector2Int ByteArrayToVector2Int(byte[] data) {
            int first0 = data.GetIndexOfElement<byte>(0,1);
            byte[] data2 = data.Take(first0).ToArray();
            byte[] data3 = data.Skip(first0 + 1).ToArray();
            return new Vector2Int(DeluxiaMethods.GetSum(data2),DeluxiaMethods.GetSum(data3));

        }
        public static byte[] Vector2IntToByteArray(this Vector2Int V2) {
            List<byte> toSend = new List<byte>();
            toSend.AddRange(DeluxiaSerialize.IntToByteArray(V2.x));
            toSend.Add(0);
            toSend.AddRange(DeluxiaSerialize.IntToByteArray(V2.y));
            return toSend.ToArray();
        }
        public static Vector2Int MultiplyEach(this Vector2Int v2,int by) {
            return new Vector2Int(v2.x * by,v2.y * by);
        }
        public static Vector2Int DivideEach(this Vector2Int v2,int by) {
            return new Vector2Int(v2.x / by,v2.y / by);
        }
		public static Vector3 Average(this IEnumerable<Vector3> v3) {
            return new(v3.Average(a=>a.x),v3.Average(a => a.y),v3.Average(a => a.z));
		}
		public static List<T> GridNeighbors<T>(this T[,] grid,Vector2Int position,bool ignoreDiagonals) {
            List<T> toSend = new();
            if(!ignoreDiagonals) {
                if(position.x > 0 && position.y > 0) {
                    toSend.Add(grid[position.x - 1,position.y - 1]);
                }
				if(position.x > 0 && position.y < grid.GetLength(1) -1) {
					toSend.Add(grid[position.x - 1,position.y + 1]);
				}
				if(position.x < grid.GetLength(0) -1 && position.y < grid.GetLength(1) -1) {
					toSend.Add(grid[position.x + 1,position.y + 1]);
				}
				if(position.x < grid.GetLength(0) -1 && position.y > 0) {
					toSend.Add(grid[position.x + 1,position.y - 1]);
				}
			}
            if(position.x > 0) {
                toSend.Add(grid[position.x - 1,position.y]);
            }
            
            if(position.y < grid.GetLength(1) -1) {
                toSend.Add(grid[position.x,position.y + 1]);
            }
            
            if(position.x < grid.GetLength(0) -1) {
                toSend.Add(grid[position.x + 1,position.y]);
            }
            
            if(position.y > 0) {
                toSend.Add(grid[position.x,position.y - 1]);
            }
            return toSend;

        }
        public static List<T> AllInRange<T>(this T[,] grid,Vector2Int position,int range) {
            List<T> toSend = new();
            for(int x = -range;x  < range + 1;x++) {
                for(int y = -range;y < range+1;y++) {
                    if(Mathf.Abs(x)+Mathf.Abs(y) <= range && position.x + x > 0 && position.y+y > 0 && position.x+ x < grid.GetLength(0)-1 && position.y+y < grid.GetLength(1)-1) {
                        if(x == 0 && y == 0) {
                            continue;
                        }
                        toSend.Add(grid[position.x+x,position.y+y]);
                    }
                }
            }
            return toSend;
        }
		public static bool InRange(Vector2Int start,Vector2Int end,int range) {
            return (Mathf.Abs(end.x - start.x) + Mathf.Abs(end.y - start.y)) <= range;
        }
        public static IEnumerator PlayAndDestroy(AudioSource source) {
            source.Play();
            yield return new WaitUntil(() => !source.isPlaying);
            Object.Destroy(source.gameObject);
        }
        public static IEnumerator StopAndDestroy(this ParticleSystem system, bool gameObjectToo = false) {
            system.Stop();
            yield return new WaitUntil(()=>system.particleCount == 0);
            if(gameObjectToo) {
                Object.Destroy(system.gameObject);
            }
            else {
                Object.Destroy(system);
            }
        }
	}
}
