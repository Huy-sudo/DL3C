import React, { useEffect, useRef } from 'react'
import styles from "./index.module.css"
import { loadModules } from "esri-loader";
import { setDefaultOptions, loadCss } from 'esri-loader';
import Map from "@arcgis/core/Map";
import SceneView from "@arcgis/core/views/SceneView";

import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import SceneLayer from "@arcgis/core/layers/SceneLayer";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import Graphic from "@arcgis/core/Graphic";

import esriRequest from "@arcgis/core/request";

function MainSection() {

  const mapRender = useRef();

  useEffect(() => {
    async function createMap(Map, SceneView, GeoJSONLayer, SceneLayer,
      GraphicsLayer, Graphic, esriRequest) {
      var createGraphic = function (data) {
        return new Graphic({
          geometry: data,
          symbol: data.symbol,
          attributes: data,
          popupTemplate: data.popupTemplate
        });
      };

    const json_options = {
      query: {
        f: "json"
      },
      responseType: "json"
    };
    // request json
    const datajson = [{"type":"polygon","rings":[["106.72180764548698","10.795383426791092","0"],["106.72123722906395","10.794975920016158","0"],["106.72175578950052","10.794320746255044","0"],["106.72230474825145","10.794645698547386","0"],["106.72180764548698","10.795383426791092","0"]],"symbol":{"type":"simple-fill","color":[227,139,79,0.6],"outline":{"color":[255,255,255],"width":1}}},{"type":"polygon","rings":[["106.72180764548698","10.795383426791092","0"],["106.72123722906395","10.794975920016158","0"],["106.72174148452224","10.794863504206955","200"],["106.72180764548698","10.795383426791092","0"]],"symbol":{"type":"simple-fill","color":[227,139,79,0.6],"outline":{"color":[255,255,255],"width":1}}},{"type":"polygon","rings":[["106.72123722906395","10.794975920016158","0"],["106.72175578950052","10.794320746255044","0"],["106.72174148452224","10.794863504206955","200"],["106.72123722906395","10.794975920016158","0"]],"symbol":{"type":"simple-fill","color":[227,139,79,0.6],"outline":{"color":[255,255,255],"width":1}}},{"type":"polygon","rings":[["106.72175578950052","10.794320746255044","0"],["106.72230474825145","10.794645698547386","0"],["106.72174148452224","10.794863504206955","200"],["106.72175578950052","10.794320746255044","0"]],"symbol":{"type":"simple-fill","color":[227,139,79,0.6],"outline":{"color":[255,255,255],"width":1}}},{"type":"polygon","rings":[["106.72180764548698","10.795383426791092","0"],["106.72230474825145","10.794645698547386","0"],["106.72174148452224","10.794863504206955","200"],["106.72180764548698","10.795383426791092","0"]],"symbol":{"type":"simple-fill","color":[227,139,79,0.6],"outline":{"color":[255,255,255],"width":1}}}]

    const datajs = new Blob([JSON.stringify(datajson)], {
      type: "application/json"
    });
    const dataUrl =  URL.createObjectURL(datajs);

    esriRequest(dataUrl, json_options).then(function (response) {
      var graphicsLayer = new GraphicsLayer();
      console.log(response);
      response.data.forEach(function (data) {
        graphicsLayer.add(createGraphic(data));
      });
      map.add(graphicsLayer);

    });
    // geojson layer
    const x = {
      "type": "FeatureCollection",
      "generator": "smartcity",
      "copyright": "Smartcity",
      "timestamp": "2021-05-27T09:28:58Z",
      "features": [
        {
          "type": "Feature",
          "properties": {
            "Building name": "Landmark Plus",
            "height": 150,
            "idb": "7"
          },
          "geometry": {
            "type": "Polygon",
            "coordinates": [

              [
                [106.72051815668941, 10.794828643368374, 0], [106.72058789412377, 10.79473642727675, 0], [106.72060130516884, 10.794749601005847, 0], [106.72082929293504, 10.794451874587102, 0], [106.72081588188996, 10.794436066096429, 0], [106.72086684386122, 10.794367562627306, 0], [106.72106532732828, 10.794504569549956, 0], [106.72099558989392, 10.794602055206878, 0], [106.72096876780378, 10.794591516218466, 0], [106.72076223770968, 10.79485762556275, 0], [106.72078101317278, 10.79487606877589, 0], [106.7207059113204, 10.794970919568495, 0], [106.72051815668941, 10.794828643368374, 0]
              ]
            ]
          },
          "id": "pp7"
        }
      ]
    }
    const blob = new Blob([JSON.stringify(x)], {
      type: "application/json"
    });
    const url =  URL.createObjectURL(blob);

    const geojsonLayer = await new GeoJSONLayer({
      url
    });

    geojsonLayer.renderer = {
      type: "simple",
      symbol: {
        type: "polygon-3d",
        symbolLayers: [
          {
            type: "extrude",
            size: 200,
            material: {
              color: "#7eadf7"
              }
            }
          ]
        }
      };
      const map = await new Map({
        basemap: "topo-vector",
        ground: "world-elevation",
        layers: [geojsonLayer] //end layers
      });

      const view = await new SceneView({
        container: mapRender.current,
        map: map,
        camera: {
          position: [106.720264, 10.786162, 300],
          heading: 0,
          tilt: 75
        }
      });

      view.popup.defaultPopupTemplateEnabled = true;
    }
    createMap(Map, SceneView, GeoJSONLayer, SceneLayer,
      GraphicsLayer, Graphic, esriRequest);
    setDefaultOptions({ url: "https://js.arcgis.com/4.16/", css: true });
    loadCss();
    // loadModules(["esri/Map",
    //   "esri/views/SceneView",
    //   "esri/layers/GeoJSONLayer",
    //   "esri/layers/SceneLayer",
    //   "esri/layers/GraphicsLayer",
    //   "esri/Graphic",
    //   "esri/request"], {css: true}).then(([Map, SceneView, GeoJSONLayer, SceneLayer,
    //     GraphicsLayer, Graphic, esriRequest]) => {

    //     var createGraphic = function (data) {
    //       return new Graphic({
    //         geometry: data,
    //         symbol: data.symbol,
    //         attributes: data,
    //         popupTemplate: data.popupTemplate
    //       });
    //     };

      //   const json_options = {
      //     query: {
      //       f: "json"
      //     },
      //     responseType: "json"
      //   };
      //   // request json
      //   esriRequest("https://is402main.blob.core.windows.net/dl3c/data.json", json_options).then(function (response) {
      //     var graphicsLayer = new GraphicsLayer();
      //     console.log(response);
      //     response.data.forEach(function (data) {
      //       graphicsLayer.add(createGraphic(data));
      //     });
      //     map.add(graphicsLayer);

      //   });
      //   // geojson layer
      //   const x = {
      //     "type": "FeatureCollection",
      //     "generator": "smartcity",
      //     "copyright": "Smartcity",
      //     "timestamp": "2021-05-27T09:28:58Z",
      //     "features": [
      //       {
      //         "type": "Feature",
      //         "properties": {
      //           "Building name": "Landmark Plus",
      //           "height": 150,
      //           "idb": "7"
      //         },
      //         "geometry": {
      //           "type": "Polygon",
      //           "coordinates": [

      //             [
      //               [106.72051815668941, 10.794828643368374, 0], [106.72058789412377, 10.79473642727675, 0], [106.72060130516884, 10.794749601005847, 0], [106.72082929293504, 10.794451874587102, 0], [106.72081588188996, 10.794436066096429, 0], [106.72086684386122, 10.794367562627306, 0], [106.72106532732828, 10.794504569549956, 0], [106.72099558989392, 10.794602055206878, 0], [106.72096876780378, 10.794591516218466, 0], [106.72076223770968, 10.79485762556275, 0], [106.72078101317278, 10.79487606877589, 0], [106.7207059113204, 10.794970919568495, 0], [106.72051815668941, 10.794828643368374, 0]
      //             ]
      //           ]
      //         },
      //         "id": "pp7"
      //       }
      //     ]
      //   }
      //   const blob = new Blob([JSON.stringify(x)], {
      //     type: "application/json"
      //   });
      //   const url = URL.createObjectURL(blob);

      //   const geojsonLayer = new GeoJSONLayer({
      //     url
      //   });

      //   geojsonLayer.renderer = {
      //     type: "simple",
      //     symbol: {
      //       type: "polygon-3d",
      //       symbolLayers: [
      //         {
      //           type: "extrude",
      //           size: 200,
      //           material: {
      //             color: "#7eadf7"
      //           }
      //         }
      //       ]
      //     }
      //   };
      //   const map = new Map({
      //     basemap: "topo-vector",
      //     ground: "world-elevation",
      //     // layers: [geojsonLayer] //end layers
      //   });

      //   const view = new SceneView({
      //     container: mapRender.current,
      //     map: map,
      //     camera: {
      //       position: [106.720264, 10.786162, 300],
      //       heading: 0,
      //       tilt: 75
      //     }
      //   });

      //   view.popup.defaultPopupTemplateEnabled = true;
      // });
  }, []);
  return (
    <section className={styles.container}>
      <div>
        <div ref={mapRender} style={{"height": "500px"}}></div>

      </div>
    </section>
  )
}

export default MainSection