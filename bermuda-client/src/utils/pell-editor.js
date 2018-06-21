import { exec, init } from 'pell'
// import '../../node_modules/pell/dist/pell.min.css';

// default for not set `upload` config
const execInsertImageAction = function () {
  const uploadImageInput = document.querySelector('.pell input[type="file"]')
  if (!uploadImageInput) {
    const url = window.prompt('Enter the image URL')
    if (url) exec('insertImage', url)
  } else {
    uploadImageInput.click()
  }
}

// just set `url`, `method` and `body` for fetch api
const uploadImage = function ({ api, data }, success, error) {
  window.fetch && window.fetch(
    api,
    {
      method: 'POST',
      body: data
    }
  )
    .then(res => res.json())
    .then(
      data => {
        // responsive data format:
        // { success: true, url: 'xxx' }
        if (data.success) success(data.url)
      },
      err => error(err)
    )
}

const initUploadImageInput = function (settings) {
  const uploadAPI = settings.upload && settings.upload.api
  if (uploadAPI) {
    const input = document.createElement('input')
    input.type = 'file'
    input.hidden = true
    input.addEventListener('change', e => {
      const image = e.target.files[0]
      const fd = new window.FormData()
      fd.append('pell-upload-image', image)
      uploadImage(
        {
          api: uploadAPI,
          data: fd
        },
        url => exec('insertImage', url),
        err => window.alert(err)
      )
    })
    settings.element.appendChild(input)
  }
}

export default function initPellEditor (element) {
  initUploadImageInput({
    element,
    upload: {
      api: 'http://localhost:53595/api/files/img/upload'
    }
  })

  return init({
    element,
    onChange: html => {
      console.log(html)
    },
    defaultParagraphSeparator: 'p',
    styleWithCSS: true,
    actions: [
      'bold',
      'italic',
      'underline',
      'strikethrough',
      'heading1',
      'heading2',
      'paragraph',
      'quote',
      'olist',
      'ulist',
      'code',
      'line',
      'link',
      {
        name: 'image',
        result: () => {
          // const url = window.prompt('Enter the image URL')
          // if (url) exec('insertImage', url)
          execInsertImageAction()
        }
      },
    ]
  })
}
