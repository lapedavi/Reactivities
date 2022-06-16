import React from 'react';
import { Button, Form } from 'semantic-ui-react';
import MyTextArea from '../../app/common/form/MyTextArea';
import MyTextInput from '../../app/common/form/MyTextInput';
import * as Yup from 'yup';
import { useStore } from '../../app/stores/store';
import { Formik } from 'formik';
import { observer } from 'mobx-react-lite';


interface Props {
    setEditMode: (editMode:boolean) => void;
}

export default observer( function ProfileEditForm({setEditMode} : Props){
    const {profileStore: {profile, updateProfile}} = useStore();
    console.log(profile);
    return (
        <Formik
            initialValues={{displayName: profile?.displayName, bio: profile?.bio}}
            onSubmit={values => {
                updateProfile(values).then(() => {
                    setEditMode(false);
                })
                //console.log(values);
            }}
            validationSchema={Yup.object({
                displayName: Yup.string().required()
            })}
        >
            {({isSubmitting, isValid, dirty}) => (
                <Form className='ui form'>
                    <MyTextInput placeholder='Display Name' name='displayName' />
                    <MyTextArea rows={3} placeholder='Add your bio' name='bio' />
                    <Button 
                        positive
                        type='submit'
                        loading={isSubmitting}
                        content='Update profile'
                        floated='right'
                        disabled={!isValid || !dirty}
                    />
                </Form>
            )}
        </Formik>
    )
})