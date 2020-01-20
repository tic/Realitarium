import React from 'react';
import {
  ScrollView,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';

import SettingsScreen from '../screens/SettingsScreen';

export default function HomeScreen(props) {
    this.launchUnity = () => {
        props.navigation.push("Unity");
    }

    return (
        <View style={styles.container}>
            <TouchableOpacity style={styles.launch} onPress={this.launchUnity}>
                <Text>Launch Unity WebGL viewer</Text>
            </TouchableOpacity>
        </View>
    );
}

HomeScreen.navigationOptions = {
    header: null,
};

const styles = StyleSheet.create({
    container: {
        marginTop: 30
    },
    launch: {
        padding: 10,
        backgroundColor: "#00ff00",
        flexDirection: "row",
        justifyContent: "center",
    },
});
