using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Deluxia.Unity {
    public class DeluxiaTooltipTrigger: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        [TextAreaAttribute]
        public string header, content;
        public float waitTime = 1.25f;
        public virtual void OnPointerEnter(PointerEventData ed){
            if(waitTime == 0) {
                if(header != "" || content != "") {
                    DeluxiaTooltip.Show(header,content);
                }
            }
            else {
                StartCoroutine("Trigger");
            }
        }
        public virtual void ChangeContent(string newContent){
            content = newContent;
        }
        IEnumerator Trigger(){
            yield return new WaitForSeconds(waitTime);
            if(header != "" || content != ""){
                DeluxiaTooltip.Show(header,content);
            }
        }
        public void OnPointerExit(PointerEventData ed){
            StopAllCoroutines();
            DeluxiaTooltip.Hide();
        }
        public void Clear(){
            header = "";
            content = "";
        }
    }
}
