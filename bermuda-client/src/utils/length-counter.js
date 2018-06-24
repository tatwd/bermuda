// 汉字 /[\u4e00-\u9fa5]/
// 双字节 /[^\x00-\xff]/
const RE = /[^\x00-\xff]/;

export default function (str) {
  let count = 0;
  let state = str
    .split('')
    .map((item) => {
      RE.test(item) ? count += 2 : count ++
      return count
    });

  return {
    length: count,
    getByLength (length) {
      return str.substring(
        0,
        state.findIndex((i) => i === Math.max(i, length))
      )
    }
  }
}
