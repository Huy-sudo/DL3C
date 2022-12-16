const mongoose = require("mongoose");

const PrismSchema = mongoose.Schema({
  type: {
    type: String,
    required: [true, "Prism must have type"],
  },
  generator: { type: String, required: [true, "Prism must have generator"] },
  copyright: {
    type: String,
  },
  timestamp: {
    type: Date,
  },
  features: [
    {
      type: {
        type: String,
        required: [true, "feature must have type"],
      },
      properties: {
        BuildingName: {
          type: String,
          required: [true, "property must have BuildingName"],
        },
        height: {
          type: Number,
          required: [true, "property must have height"],
        },
        idb: { type: String, required: [true, "property must have idb"] },
      },
      geometry: {
        type: {
          type: String,
          required: [true, "geometry must have type"],
          enum: ["MultiPolygon", "Polygon"],
        },
        coordinates: [[[]]],
      },
      id: {
        type: String,
      },
    },
  ],
});

const Prism = mongoose.model("Prism", PrismSchema);
module.exports = Prism;
