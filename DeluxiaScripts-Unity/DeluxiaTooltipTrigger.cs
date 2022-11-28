using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Deluxia.Unity {
    public class DeluxiaTooltipTrigger: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        [TextAreaAttribute]
        public string header, content;
        public float waitTime = 1.25f;
        private IEnumerator last = null;
        public virtual void OnPointerEnter(PointerEventData ed){
            //Debug.Log("Entered " + gameObject.name);
            if(waitTime == 0) {
                if(header != "" || content != "") {
                    DeluxiaTooltip.Show(header,content);
                }
            }
            else {
                if(last != null) {
					//Debug.Log("StopLast 1");
					StopCoroutine(last);
				}
				last = Trigger();
                StartCoroutine(last);
            }
        }
        public virtual void ChangeContent(string newContent){
            content = newContent;
        }
        IEnumerator Trigger(){
            //Debug.Log("Wait " + waitTime);
            yield return new WaitForSeconds(waitTime);
            if(header != "" || content != ""){
                //Debug.Log("SHOW");
                DeluxiaTooltip.Show(header,content);
            }
        }
        public void OnPointerExit(PointerEventData ed){
            if(last != null) {
                //Debug.Log("StopLast 2");
                StopCoroutine(last);
                last = null;
            }
            DeluxiaTooltip.Hide();
        }
        public void Clear(){
            header = "";
            content = "";
        }
    }
}
