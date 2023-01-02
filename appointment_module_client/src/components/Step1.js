import React, {useEffect, useState} from 'react';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import StorefrontIcon from '@mui/icons-material/Storefront';
import ListItemText from '@mui/material/ListItemText';
import ContentCutOutlinedIcon from '@mui/icons-material/ContentCutOutlined';
import { ListItemIcon } from '@mui/material';
import axios from "axios";

/* [{businessId: 1, businessName:'Studio 786 Salon', icon: <StorefrontIcon/>},{businessId: 2, businessName: 'Skull & Thrones', icon:<ContentCutOutlinedIcon/>}] */

export default function Step1({getBusinessId}) {
  const [selectedIndex, setSelectedIndex] = useState(null);
  const [listOfBusinesses, setListOfBusinesses] = useState([])
  const [selectedBusiness, setSelectedBusiness] = useState(null);
  const [icons, setIcons] = useState([
    {
      iconName:"scissorscutoutline",
      iconSymbol: <ContentCutOutlinedIcon/>
    },
    {
      iconName:"storefronticon",
      iconSymbol:<StorefrontIcon/>
    }
  ])
  const handleListItemClick = (businessId, index) => {
      //this function sets business id into state
      getBusinessId(businessId, selectedIndex);

    setSelectedIndex(index);
 
  };



  //use effect to populate list of businesses
  useEffect(() =>{
    //GET REQUEST TO POPULATE listOfBusinesses state array  d

    axios.get("https://localhost:7004/api/get_all_businesses")
    .then((results) =>{
      console.log(results.data)
      setListOfBusinesses(results.data);

    })

  }, [])
  return (
    <Box sx={{ width: '100%', minWidth:400, bgcolor: 'background.paper' }}>
     
      <List component="nav" aria-label="secondary mailbox folder">
      {listOfBusinesses.map((business, idx) =>{
        return(
          <>
          <ListItemButton
          selected={selectedIndex === idx }
          onClick={(event) => handleListItemClick(business.businessId, idx)}
        >
        <ListItemIcon>
          {icons.map((icon) =>{
            if(icon.iconName === business.icon){
              return icon.iconSymbol;
            }
          })}
          </ListItemIcon>
          <ListItemText primary={business.businessName} />
        </ListItemButton>
          </>
        )
      })}

      </List>
    </Box>
  );
}

