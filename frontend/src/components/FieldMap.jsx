import React from "react";
import { MapContainer, TileLayer, Polygon, Marker, Popup } from "react-leaflet";

const FieldMap = () => {
  // Dummy field polygon coordinates (lat, lng)
  const fieldCoords = [
    [
      [7.847, -1.022],
      [7.847, -1.016],
      [7.843, -1.016],
      [7.843, -1.022],
    ],
  ];

  return (
    <div className="map-section">
      <h3>🗺️ Field Map</h3>
      <MapContainer center={[7.845, -1.02]} zoom={16} scrollWheelZoom={true} style={{ height: "400px", borderRadius: "12px", overflow: "hidden" }}>
        <TileLayer
          attribution='&copy; <a href="https://openstreetmap.org">OpenStreetMap</a>'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <Polygon positions={fieldCoords} pathOptions={{ color: "green", fillOpacity: 0.4 }} />
        <Marker position={[7.845, -1.02]}>
          <Popup>Your Field</Popup>
        </Marker>
      </MapContainer>
    </div>
  );
};

export default FieldMap;
