import React from "react";
import "../styles/Dashboard.css";
import NDVIChart from "../components/NDVICharts.jsx";
import FieldMap from "../components/FieldMap";
import NDVILegend from "../components/NDVILegend";
import SoilDroughtIndex from "../components/SoilDroughtIndex";
import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";

const Dashboard = () => {
  return (
     <>
      <Navbar/>
      <div className="dashboard-wrapper">
        <div className="dashboard-header">
          <h2>Welcome Back, Farmer Nana Yaa 👩🏽‍🌾</h2>
          <p>Your farm insights are ready.</p>
        </div>

        <div className="filter-bar">
          <select>
            <option>Index: NDVI</option>
          </select>
          <select>
            <option>Group</option>
          </select>
          <select>
            <option>Crop</option>
          </select>
          <input type="date"/>
          <button className="clear-btn">Clear</button>
          <button className="new-field-btn">+ New Field</button>
        </div>

        <div className="field-table-section">
          <h3>Your Fields</h3>
          <table>
            <thead>
            <tr>
              <th>Field</th>
              <th>Location</th>
              <th>Coordinates</th>
              <th>Area (ha)</th>
              <th>Sowing Date</th>
              <th>NDVI</th>
              <th>Change</th>
            </tr>
            </thead>
            <tbody>
            <tr>
              <td>F.Name1</td>
              <td>Ashimoto</td>
              <td>30.2887°N, 30.5536°E</td>
              <td>46.2</td>
              <td>06 June 2025</td>
              <td>0.54</td>
              <td className="positive">+0.08</td>
            </tr>
            <tr>
              <td>F.Name2</td>
              <td>Ashanti</td>
              <td>23.0874°N, 23.5820°E</td>
              <td>20.6</td>
              <td>10 June 2025</td>
              <td>0.61</td>
              <td className="negative">-0.06</td>
            </tr>
            <tr>
              <td>F.Name3</td>
              <td>Zango</td>
              <td>23.0874°N, 23.5820°E</td>
              <td>19.5</td>
              <td>13 June 2020</td>
              <td>0.71</td>
              <td className="negative">-0.01</td>
            </tr>
            </tbody>
          </table>
        </div>

        <div className="chart-section">
          <NDVIChart/>
        </div>
        <div className="map-wrapper">
          <FieldMap/>
        </div>
        <div className="ndvi-legend">
          <NDVILegend/>
        </div>

        <div className="soil-drought">
          <SoilDroughtIndex/>
        </div>
      </div>
     <Footer/>
    </>
  );
};

export default Dashboard;
