const BodyCom = require("../models/bodyComplex");
const catchAsync = require("../utils/catchAsync");

exports.getAllBodyCom = catchAsync(async (req, res, next) => {
  const allBodyCom = await BodyCom.find({});
  res.status(200).json({
    status: "success",
    allBodyCom,
  });
});

exports.createBodyCom = catchAsync(async (req, res, next) => {
  //   const newBodyCom = await BodyCom.create({
  //     ...req.body,
  //   });
  //   if (!newBodyCom) return next(new Error("Create unsuccessfully"));
  const listBodyCom = req.body;

  for (const bodyCom of listBodyCom) {
    let newBodyCom;
    try {
      newBodyCom = await BodyCom.create({
        ...bodyCom,
      });
    } catch (err) {
      return next(err);
    }
    if (!newBodyCom)
      return next(new Error(`Create bodyCom ${index} unsuccessfully`));
  }

  res.status(201).json({
    status: "success",
  });
});
