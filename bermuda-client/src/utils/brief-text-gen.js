/**
 * 摘要生成器
 */
const TWO_LABEL_RE = /<(\/?)(BODY|SCRIPT|P|DIV|H1|H2|H3|H4|H5|H6|ADDRESS|PRE|TABLE|TR|TD|TH|INPUT|SELECT|TEXTAREA|OBJECT|A|UL|OL|LI|BASE|META|LINK|HR|BR|PARAM|IMG|AREA|INPUT|SPAN)[^>]*(>?)/ig;
const ONE_LABEL_RE = /BASE|META|LINK|HR|BR|PARAM|IMG|AREA|INPUT/i

export default function (text, length) {
  if (text.length < length)
    return text;

  let foremost = text.substr(0,length);

  let Stack = new Array();
  let posStack = new Array();

  while (true) {
    var newone = TWO_LABEL_RE.exec(foremost);

    if (newone == null)
      break;

    if (newone[1] == '') {
      var Elem = newone[2];
      if (Elem.match(ONE_LABEL_RE) && newone[3]!= ''){
        continue;
      }

      Stack.push(newone[2].toUpperCase());
      posStack.push(newone.index);

      if (newone[3] == '')
        break;
    } else {
      var StackTop = Stack[Stack.length-1];
      var End = newone[2].toUpperCase();

      if (StackTop == End){
        Stack.pop();
        posStack.pop();

        if (newone[3] == ''){
          foremost = foremost + '>';
        }
      }

    }
  }
  var cutpos = posStack.shift();
  foremost = foremost.substring(0, cutpos);

  return foremost;
}
