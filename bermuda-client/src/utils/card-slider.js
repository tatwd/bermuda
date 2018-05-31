export default (config) => {
  const { element, trans, duration, interval = 3000, timing } = config;

  if (!element) {
    console.error('ERROR(card-slider.js:5): \'element\' is undefined!')
    return;
  }

  const SLIDE_X = trans.x; // x 轴平移标准距离

  let i, x, toleft, inter, count, playing;

  count = parseInt(
    (SLIDE_X * element.childNodes.length  - element.offsetWidth) / SLIDE_X
  );
  element.style.transition = `all ${duration}s ${timing}`;

  i = x = toleft = 0;
  playing = () => {
    toleft = -Math.pow(-1, (i++ / count) ^ 0); // -(-1)^n

    x = toleft < 0
      ? x - SLIDE_X
      : x + SLIDE_X;

    element.style.transform = `translateX(${x}px)`;
  };

  // start playing
  inter = setInterval(playing, interval);

  // add mouse listener
  element.addEventListener('mouseenter', () => clearInterval(inter));
  element.addEventListener('mouseleave', () => inter = setInterval(playing, interval));
};
