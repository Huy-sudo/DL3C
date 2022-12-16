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
    setDataJson(response);
    console.log(dataJson)
  }
  async function getDataGeoJson() {
    let response = await getAllPrisms();
    setDataJson(setDataGeoJson);
    console.log(dataGeoJson)
  }

  useEffect(() => {
    getDataJson();
    getDataGeoJson();
    console.log(process.env.API_URL)
  }, [])


  return (
    <div ref={modelRef}></div>
  )
}

export default MainModel