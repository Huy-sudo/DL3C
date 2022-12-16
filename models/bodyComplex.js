const mongoose = require("mongoose");

const bodyComplexSchema = mongoose.Schema({
  _comment: {
    type: String,
  },
  type: {
    type: String,
    required: [true, "bodyComplex must have have total type"],
    default: "polygon",
  },
  rings: [
    [{ type: Number, required: [true, "bodyComplex must have have rings"] }],
  ],
  symbol: {
    type: {
      type: String,
      required: [true, "bodyComplex must have symbol-type"],
      enum: ["simple-fill"],
    },
    color: {
      type: mongoose.Mixed,
      required: [true, "bodyComplex must have symbol-color"],
    },
    outline: {
      color: {
        type: mongoose.Mixed,
        required: [true, "bodyComplex must have symbol-outline-color"],
      },
      width: {
        type: Number,
        required: [true, "bodyComplex must have symbol-outline-width"],
      },
    },
  },
});

const bodyComplex = mongoose.model("bodyComplex", bodyComplexSchema);

module.exports = bodyComplex;
