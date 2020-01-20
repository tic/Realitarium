import React from 'react';
import { View, Text } from 'react-native';

export default function SettingsScreen() {
    /**
    * Go ahead and delete ExpoConfigView and replace it with your content;
    * we just wanted to give you a quick view of your config.
    */
    return (
        <View>
            <Text>Settings located here. Possible settings include:</Text>
            <Text>User's name (to be recorded for the instructor)</Text>
            <Text>User's ID (to be recorded for the instructor)</Text>
        </View>
    );
}

SettingsScreen.navigationOptions = {
    title: 'Settings',
};
