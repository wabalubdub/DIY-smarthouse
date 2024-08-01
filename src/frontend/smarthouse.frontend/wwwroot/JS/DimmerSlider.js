window.dimmerSlider = {
  GetBoundingClientRect: function (element) {
    if (!element) return null;
    var rect = element.getBoundingClientRect();
    return { left: rect.left, width: rect.width };
  },
};
