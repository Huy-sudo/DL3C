const Prism = require("../models/Prism");
const catchAsync = require("../utils/catchAsync");

exports.getAllPrisms = catchAsync(async (req, res, next) => {
  const allPrism = await Prism.find({});
  res.status(200).json({
    status: "success",
    allPrism,
  });
});

exports.createPrism = catchAsync(async (req, res, next) => {
  const newPrism = await Prism.create({
    ...req.body,
  });
  if (!newPrism) return next(new Error("Create unsuccessfully"));

  res.status(201).json({
    status: "success",
    prism: newPrism,
  });
});
