/**
 * Format img url of a object.
 * @param {Array, Object} obj
 * @param {String} url
 */
export default function (obj, url) {
  return  !Array.isArray(obj)
      ? forObject(obj, url)
      : forArray(obj, url);
}

// for object
function forObject (obj, url) {
  if (toString.call(obj) === '[object Object]') {
    Object.keys(obj)
      .forEach(key => {
        if (key.includes('url') && obj[key] && obj[key].startsWith('/'))
          obj[key] = url + obj[key]
        else
          obj[key] = forObject(obj[key], url)
      })
  }
  return obj;
}

// for array
function forArray (arr, url) {
  return arr.map(obj => forObject(obj, url));
}
