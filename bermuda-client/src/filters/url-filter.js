// old idea
/*
function imgUrlify (obj, url) {
  return !Array.isArray(obj)
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
*/

/**
 * Format url string for starting with `/`
 * @param {String} value
 */
export default function (value) {
  return value.replace(/^\//g, process.env.URL);
}
