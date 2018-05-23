/**
 * Format img url of a object.
 * @param {*} obj
 * @param {*} url
 */
export default function (obj, url) {
  Object.keys(obj)
    .filter(key => key.match(/url/))
    .forEach(key => {
      if (obj[key])
        obj[key] = url + obj[key]
    })

  return obj;
}
