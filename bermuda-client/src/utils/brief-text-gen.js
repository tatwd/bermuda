import lengthCounter from './length-counter'

/**
 * 摘要生成器，用于动态内容的摘要
 */
const DOUBLE_LABEL_RE = /<(\/?)(BODY|SCRIPT|P|DIV|H1|H2|H3|H4|H5|H6|ADDRESS|PRE|TABLE|TR|TD|TH|INPUT|SELECT|TEXTAREA|OBJECT|A|UL|OL|LI|BASE|META|LINK|HR|BR|PARAM|IMG|AREA|INPUT|SPAN|BLOCKQUOTE)[^>]*(>?)/ig;
const SINGLE_LABEL_RE = /BASE|META|LINK|HR|BR|PARAM|IMG|AREA|INPUT/i

export default function (text, length) {
  if (text.length < length)
    return text;

  let foremost = lengthCounter(text).getByLength(length); // text.substr(0, length);

  let stack = [];
  let posStack = [];
  let pos = 0;

  while (true) {
    let matched = DOUBLE_LABEL_RE.exec(foremost);

    if (matched == null)
      break;
    pos = matched.index
    if (matched[1] == '') {
      let element = matched[2];
      if (element.match(SINGLE_LABEL_RE) && matched[3]!= '') {
        continue;
      }

      stack.push(matched[2].toUpperCase());
      posStack.push(matched.index);

      if (matched[3] == '')
        break;
    } else {
      let stackTop = stack[stack.length - 1];
      let end = matched[2].toUpperCase();

      if (stackTop == end){
        stack.pop();
        posStack.pop();

        if (matched[3] == '') {
          foremost = foremost + '>';
        }
      }
    }
  }
  // debugger
  // get labels string
  let labels = endWith(stack)

  // substring from 0 -> posStack[posStack.length - 1]
  let cutpos = posStack.pop();
  if (cutpos) {
    if (stack.length > 1)
      foremost = foremost.substring(0, cutpos);
    foremost = appendLabels(
        length,
        foremost,
        labels
      )
  } else {
    if (pos !== cutpos)
      foremost = foremost.substring(0, pos);
    foremost = appendLabels(
      length,
      foremost,
      labels
    )
  }

  return foremost;
}

function appendLabels (maxLength, str, labels) {
  const strLength = lengthCounter(str).length;
  const labelsLength = labels.length;
  const computedLength = function () {
    let dist = maxLength - strLength
    return dist >= labelsLength  ? 0 : labelsLength - dist
  }
  const RE = new RegExp(`.{${ computedLength() }}$`)
  return str.replace(RE, labels)
}

function endWith (arr) {
  let str = ''
  let len = arr.length
  let isTrue = function (i) {
    return len > 1
      ? i < len - 1
      : i <= len - 1;
  }

  for (let i = 0; isTrue(i); i++) {
    if (!SINGLE_LABEL_RE.test(arr[i])) {
      let label = `</${arr[i].toLowerCase()}>`
      str = label + str
    }
  }
  return str;
}
