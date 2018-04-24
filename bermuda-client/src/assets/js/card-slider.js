export default (config) => {
  const { element, trans, count, duration, interval = 300 } = config;

  if (!element)
    return;

  const SLIDE_X = trans.x;
  let i = 0, toleft = 0, x = 0, inter;

  inter = windows.setInterval(() => {
      toleft = -Math.pow(-1, (i / count) ^ 0); // 指数取整

      x = toleft < 0
        ? x - SLIDE_X
        : x + SLIDE_X;

      element.style.transform = `translateX(${x}px)`;
      i++;
  }, interval);
};
