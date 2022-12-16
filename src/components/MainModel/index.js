import React, { useEffect, useState, useRef } from 'react'
import Map from "@arcgis/core/Map";
import SceneView from "@arcgis/core/views/SceneView";

import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import SceneLayer from "@arcgis/core/layers/SceneLayer";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import Graphic from "@arcgis/core/Graphic";

import esriRequest from "@arcgis/core/request";
import { getAllBodyCom } from '../../apis/bodyCom';
import { getAllPrisms } from '../../apis/prism';

function MainModel() {
  const modelRef = useRef();
  const [dataJson, setDataJson] = useState();
  const [dataGeoJson, setDataGeoJson] = useState();

  async function getDataJson() {
    let response = await getAllBodyCom();
    setDataJson(response.data.allBodyCom);
    console.log(dataJson)
  }
  async function getDataGeoJson() {
    let response = await getAllPrisms();
    setDataGeoJson(response.data.allPrism);
    console.log(dataGeoJson)
  }

  useEffect(() => {
    getDataJson();
    getDataGeoJson();


    async function createMap(Map, SceneView, GeoJSONLayer, SceneLayer,
      GraphicsLayer, Graphic, esriRequest) {

      var createGraphic = function (data) {
        return new Graphic({
          geometry: data,
          symbol: data.symbol,
          attributes: data,
          popupTemplate: data.popupTemplate,
        });
      };

      const json_options = {
        query: {
          f: "json"
        },
        responseType: "json"
      };

      const dataJsonBlob = new Blob([JSON.stringify(dataJson)], {
        type: "application/json"
      });
      const dataJsonUrl = URL.createObjectURL(dataJsonBlob);

      esriRequest(dataJsonUrl, json_options).then(function (response) {
        var graphicsLayer = new GraphicsLayer();
        console.log(response);
        response.data.forEach(function (data) {
          graphicsLayer.add(createGraphic(data));
        });
        map.add(graphicsLayer);

      });
      const map = await new Map({
        basemap: "topo-vector",
        ground: "world-elevation",
        // layers: [geojsonLayer] //end layers
      });

      const view = new SceneView({
        container: modelRef.current,
        map: map,
        camera: {
          position: [106.70117749271675, 10.776408362678433, 60],
          heading: 90,
          tilt: 80,
        },
      });
      view.popup.defaultPopupTemplateEnabled = true;
    }
    createMap(Map, SceneView, GeoJSONLayer, SceneLayer,
      GraphicsLayer, Graphic, esriRequest);
  }, [])


  return (
    <div ref={modelRef}></div>
  )
}

export default MainModel